using Common.DAO.Access;
using Common.Filter;
using Microsoft.EntityFrameworkCore;
using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Model.Custom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace SpeedFramework.DAO.Model.Custom.Filter
{
    public class FilterEngine
    {
        public DbSet<T> GetDbSet<T>(IModelContext db,string typeName) where T : class, TEntity
        {
            Type type = Type.GetType(typeName);
            DbSet<T> set = null;

            if (type != null)
                set = db.GetDbContext().Set<T>();

            return set;
        }

        public static Expression CreateExpression(Type type, string propertyName, ParameterExpression pe)
        {
            Expression body = pe;
            foreach (var member in propertyName.Split('.'))
            {
                body = Expression.Property(body, member);
            }
            return body;
        }

        public Dictionary<string, object> getPropertyMapForSelect(Type t, object o, List<FilterResultField> filterResultFields)
        {
            Dictionary<string, object> _map = new Dictionary<string, object>();
            _map.Add("Id",  t.GetProperty("Id").GetValue(o));

            foreach (FilterResultField filterResultField in filterResultFields)
            {
                if (!filterResultField.ExcludeInQueryExpression)
                {
                    _map.Add(filterResultField.Expression, t.GetProperty(filterResultField.Expression).GetValue(o));
                }
                else
                {
                    _map.Add(filterResultField.Expression, filterResultField.ViewTransformExpression);
                }
            }
            return _map;
        }

        public IEnumerable<dynamic>  GetFilteredWrapper(int Id, IEnumerable<FilterField> filterFields, IModelContext db, IUserContext userContext, int s, int n)
        {
            var filterMethod = GetType().GetMethod("GetFiltered");
            Filter f = db.Filters.Where(o => o.Id == Id).FirstOrDefault();
            Type t = Type.GetType(f.ApplicationEntity.Name);

            var filterGenericMethod = filterMethod.MakeGenericMethod(new[] { t });

            List<FilterResultField> resultFields = new List<FilterResultField>();
            resultFields = db.FilterResultFields.Where(m => m.CommonFilterId == Id & !m.Inactive).ToList();
            IEnumerable<dynamic> result = (IEnumerable<dynamic>)filterGenericMethod.Invoke(this, new object[] { Id, filterFields, db, userContext, s, n });
            result = result.Select(m => getPropertyMapForSelect(t,m,resultFields)).ToList();
            return result;
        }


        public IEnumerable<dynamic> GetGlobalFilteredWrapper(string name, string value, IModelContext db, IUserContext userContext, int s, int n)
        {
            var filterMethod = GetType().GetMethod("GetGlobalFiltered");
//            Type[] types =  Assembly.GetExecutingAssembly().GetTypes();

//            Type t = Assembly.GetExecutingAssembly().GetTypes().Where(p => p.AssemblyQualifiedName==name).FirstOrDefault();
            Type t = Type.GetType(name);

            List<ApplicationEntityProperty> applicationEntityProperties = db.ApplicationEntityProperties.Where(m => m.IncludeInName & m.ApplicationEntity.Name == name).ToList();

            var filterGenericMethod = filterMethod.MakeGenericMethod(new[] { t });

            List<FilterResultField> resultFields = new List<FilterResultField>();
            List<FilterField> filterFields = new List<FilterField>();

            foreach (ApplicationEntityProperty applicationEntityProperty in applicationEntityProperties)
            {
                resultFields.Add(new FilterResultField { Expression = applicationEntityProperty.Name });
                filterFields.Add(new FilterField { FilterValue = value, FilterOperator = FilterOperator.CONTAINS, Field = new Field { ApplicationEntityProperty = applicationEntityProperty } });
            }

            resultFields.Add(new FilterResultField { Expression = "ApplicationNumber" });

            IEnumerable<dynamic> result = (IEnumerable<dynamic>)filterGenericMethod.Invoke(this, new object[] { filterFields, db, userContext, s, n });
            result = result.Select(m => getPropertyMapForSelect(t, m, resultFields)).ToList();
            return result;
        }

        public IEnumerable<T> GetGlobalFiltered<T>(IEnumerable<FilterField> filterFields, IModelContext db, IUserContext userContext, int s, int n) where T : class, TEntity
        {
            FilterEngine fe = new FilterEngine();
            DbSet<T> set = fe.GetDbSet<T>(db, typeof(T).AssemblyQualifiedName);


            IQueryable<T> results = null;
            List<Expression> expressions = new List<Expression>();
            ParameterExpression pe = Expression.Parameter(typeof(T), "_obj");

            foreach (FilterField ff in filterFields)
            {
                Expression e = fe.GetWhereExpression<T>(pe, ff, userContext);
                expressions.Add(e);
            }

            MethodCallExpression m = fe.GetWhere<T>(set, expressions, pe);
            results = set.AsQueryable().Provider.CreateQuery<T>(m);
            return results.ToList();
        }


        public FilterResult<dynamic> GetFilteredWithOffsetWrapper(int Id, IEnumerable<FilterField> filterFields, IModelContext db, IUserContext userContext, int s, int n)
        {
            IEnumerable<dynamic> list = GetFilteredWrapper(Id, filterFields, db, userContext, s, n);

            var filterMethod = GetType().GetMethod("GetFilteredWithOffsetDynamic");
            Filter f = db.Filters.Where(o => o.Id == Id).FirstOrDefault();
            Type t = Type.GetType(f.ApplicationEntity.Name);
            var filterGenericMethod = filterMethod.MakeGenericMethod(new[] { t });

            ParameterExpression pe = Expression.Parameter(t, "_obj");
            f.PageSize = 10;
            f.PageIndex =1;
            List<FilterResultField> resultFields = new List<FilterResultField>();
            resultFields = db.FilterResultFields.Where(m => m.CommonFilterId == Id & !m.Inactive).ToList();
            FilterResult<dynamic> result = (FilterResult<dynamic>)filterGenericMethod.Invoke(this, new object[] {Id, filterFields, db, userContext,s,n });
            result.Result = result.Result.Select(m => getPropertyMapForSelect(t, m, resultFields)).ToList();
            return result;
        }

        public FilterResult<dynamic> GetFilteredWithOffsetDynamic<T>(int Id, IEnumerable<FilterField> filterFields, IModelContext db, IUserContext userContext, int s, int n) where T : class, TEntity
        {
            Filter f = db.Filters.Where(o => o.Id == Id).FirstOrDefault();
            FilterEngine fe = new FilterEngine();
            DbSet<T> set = fe.GetDbSet<T>(db, f.ApplicationEntity.Name);

            IEnumerable<FilterField> fields = db.FilterFields.Where(o => o.CommonFilter.Id == f.Id & !o.Inactive).ToList();

            IQueryable<T> results = null;
            List<Expression> expressions = new List<Expression>();
            ParameterExpression pe = Expression.Parameter(typeof(T), "_obj");

            foreach (FilterField ff in fields)
            {
                //                if (filterFields.Select(x => x.Id).ToList().Contains(ff.Id))
                {
                    if (ff.LockValue)
                    {
                        Expression e = fe.GetWhereExpression<T>(pe, ff, userContext);
                        expressions.Add(e);
                    }
                    else
                    {
                        //                        ff.FilterValue = filterFields.Where(x => x.Id == ff.Id).FirstOrDefault().FilterValue;
                        Expression e = fe.GetWhereExpression<T>(pe, ff, userContext);
                        expressions.Add(e);
                    }
                }

            }

            MethodCallExpression m = fe.GetWhere<T>(set, expressions, pe);
            results = set.AsQueryable().Provider.CreateQuery<T>(m);
            int count = results.Count();
            var property = typeof(T).GetProperty("Id");

            var propertyAccess = Expression.MakeMemberAccess(pe, property);
            var orderByExpression = Expression.Lambda(propertyAccess, pe);
            var resultExpression = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { typeof(T), property.PropertyType },
                results.Expression, Expression.Quote(orderByExpression));
            IQueryable<T> _result = (IOrderedQueryable<T>)results.Provider.CreateQuery<TEntity>(resultExpression);

            f.PageIndex = n;
            f.PageSize = s;
            IEnumerable<T> result = _result.
                Skip((f.PageIndex - 1) * f.PageSize).
                Take(f.PageSize).ToList();

            return new FilterResult<dynamic>
            {
                Result = (IEnumerable<dynamic>)result,
                Count = count
            };

        }


        public IEnumerable<T> GetFiltered<T>(int Id, IEnumerable<FilterField> filterFields, IModelContext db, IUserContext userContext, int s, int n) where T : class, TEntity
        {
//            db.Filter.Select(k => ( k.ApplicationEntity ,  ));
            Filter f = db.Filters.Where(o => o.Id == Id).FirstOrDefault();
            FilterEngine fe = new FilterEngine();
            DbSet<T> set = fe.GetDbSet<T>(db, f.ApplicationEntity.Name);
//            set = fe.GetDbSet<T>(db, typeof(T).FullName);

            IEnumerable<FilterField> fields = db.FilterFields.Where(o => o.CommonFilter.Id == f.Id).ToList();

            IQueryable<T> results = null;
            List<Expression> expressions = new List<Expression>();
            ParameterExpression pe = Expression.Parameter(typeof(T), "_obj");

            foreach (FilterField ff in fields)
            {
//                if (filterFields.Select(x => x.Id).ToList().Contains(ff.Id))
                {
                    if (ff.LockValue)
                    {
                        Expression e = fe.GetWhereExpression<T>(pe, ff, userContext);
                        expressions.Add(e);
                    }
                    else
                    {
//                        ff.FilterValue = filterFields.Where(x => x.Id == ff.Id).FirstOrDefault().FilterValue;
                        Expression e = fe.GetWhereExpression<T>(pe, ff, userContext);
                        expressions.Add(e);
                    }
                }

            }

            MethodCallExpression m = fe.GetWhere<T>(set, expressions, pe);
            results = set.AsQueryable().Provider.CreateQuery<T>(m);
            return results.ToList();
        }

        /*
        public async Task<IEnumerable<dynamic>> GetFiltered(int Id,ModelContext db)
        {
            Filter f = db.Filter.Where(o => o.Id == Id).FirstOrDefault();
            Type t = Type.GetType(f.ApplicationEntity.Name);

            FilterEngine fe = new FilterEngine();
//            DbSet set = db.Set(t);
            IQueryable<dynamic> set = GetByName_ReflectionTest(f.ApplicationEntity.Name, db);
            IEnumerable<FilterField> fields = db.FilterFields.Where(o => o.CommonFilter.Id == f.Id).ToList();

            IQueryable results = null;
            List<Expression> expressions = new List<Expression>();
            ParameterExpression pe = Expression.Parameter(t, "_obj");

            foreach (FilterField ff in fields)
            {
                    if (ff.LockValue)
                    {
                        Expression e = fe._GetExpression(pe, ff,t);
                        expressions.Add(e);
                    }

            }

            MethodCallExpression m = fe._GetWhere(set, expressions, pe);
            IDbSet<Asset> _set = (IDbSet<Asset>)set;
             results = set.Provider.CreateQuery(m);
            return await results.ToListAsync();
        }
*/


        

        
        public MethodCallExpression GetWhere<T>(IQueryable queryableData, List<Expression> predicateBody, ParameterExpression pe) where T: class, TEntity
        {
            MethodCallExpression whereCallExpression = null;
            if (predicateBody.ToList().Count != 0)
            {
                Expression resultantPredicateBody = predicateBody.ToList()[0];
                for (int i = 1; i < predicateBody.Count(); i++)
                {
                    resultantPredicateBody = Expression.AndAlso(predicateBody.ToList()[i], resultantPredicateBody);
                }

                whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { queryableData.ElementType },
                queryableData.Expression,
                Expression.Lambda<Func<T, bool>>(resultantPredicateBody, new ParameterExpression[] { pe }));
            }
            else
            {
                Expression resultantPredicateBody = Expression.Constant(true);
                whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { queryableData.ElementType },
                queryableData.Expression,
                Expression.Lambda<Func<T, bool>>(resultantPredicateBody, new ParameterExpression[] { pe }));
            }

             return whereCallExpression;
        }



        /*
        public MethodCallExpression GetSelect<T>(IQueryable queryableData, List<Expression> predicateBody, ParameterExpression pe) where T : class, TEntity
        {
            
            Expression resultantPredicateBody = predicateBody.ToList()[0];
            for (int i = 1; i < predicateBody.Count(); i++)
            {
                resultantPredicateBody = Expression.Quote(new { predicateBody.ToList()[i] });
            }

            MethodCallExpression whereCallExpression = Expression.Call(
            typeof(Queryable),
            "Select",
            new Type[] { queryableData.ElementType },
            queryableData.Expression,
            Expression.Lambda<Func<T, bool>>(resultantPredicateBody, new ParameterExpression[] { pe }));


            return whereCallExpression;
        }*/

        public string GetValues(string value, IUserContext userContext)
        {
            switch (value)
            {
                case "${Date.Now}":
                    return DateTime.Now.ToString() ;
                case "${Current.User}":
                    return ""+userContext.CurrentUserId;
                case "${Current.Role}":
                    return ""+userContext.CurrentRoleId;
            }
            return value;
        }



        public Expression GetWhereExpression<T>(ParameterExpression pe, FilterField filterField, IUserContext userContext)
        {
            Expression final = null;
            Type _type = typeof(T);
            filterField.FilterValue = GetValues(filterField.FilterValue, userContext);
            switch (filterField.Field.ApplicationEntityProperty.type.ToLower())
            {
                case "system.string, mscorlib, version=4.0.0.0, culture=neutral, publickeytoken=b77a5c561934e089":
                    {
                        switch (filterField.FilterOperator)
                        {
                            case FilterOperator.EQUALS:
                                {
                                    Expression left = Expression.Property(pe, _type.GetProperty(filterField.Field.ApplicationEntityProperty.Name));
                                    Expression right = Expression.Constant(filterField.FilterValue);
                                    final = Expression.Equal(left, right);
                                    break;
                                }
                            case FilterOperator.CONTAINS:
                                {
                                    if(String.IsNullOrEmpty(filterField.FilterValue))
                                    {
                                        final = Expression.Constant(true); ;
                                    }
                                    else
                                    {
                                        Expression right = Expression.Constant(filterField.FilterValue ?? String.Empty);
                                        Expression zero = Expression.Constant(0);

                                        Type t = _type.GetProperty(filterField.Field.ApplicationEntityProperty.Name).PropertyType;
                                        MethodInfo methodInfo = t.GetMethod("IndexOf", new Type[] { typeof(string) });

                                        //                                    Expression _property = Expression.Property(Expression.Parameter(_type, "_obj"), filterField.Field.ApplicationEntityProperty.Name);
                                        Expression _property = Expression.Property(pe, filterField.Field.ApplicationEntityProperty.Name);
                                        //                                    Expression lambda = Expression.Lambda(_property, Expression.Parameter(_type, "x"));

                                        Expression left = Expression.Call(_property, methodInfo, right);
                                        //Expression left = Expression.Call(pe,methodInfo, right);
                                        final = Expression.GreaterThanOrEqual(left, zero);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "system.double, mscorlib, version=4.0.0.0, culture=neutral, publickeytoken=b77a5c561934e089":
                    {
                        switch (filterField.FilterOperator)
                        {
                            case FilterOperator.EQUALS:
                                {
                                    Expression left = CreateExpression(_type, filterField.Field.ApplicationEntityProperty.Name, pe);
                                    Double i = Double.Parse(filterField.FilterValue??"0.0");
                                    Expression right = Expression.Constant(i, typeof(double));
                                    final = Expression.Equal(left, right);
                                    break;
                                }
                            case FilterOperator.GREATER_THAN:
                                {
                                    Expression left = CreateExpression(_type, filterField.Field.ApplicationEntityProperty.Name, pe); // Expression.Property(pe, _type.GetProperty(property));

                                    Double i = Double.Parse(filterField.FilterValue ?? "0.0");
                                    Expression right = Expression.Constant(i, typeof(double));
                                    final = Expression.GreaterThan(left, right);
                                    break;
                                }
                            case FilterOperator.LESS_THAN:
                                {
                                    Expression left = Expression.Property(pe, _type.GetProperty(filterField.Field.ApplicationEntityProperty.Name));
                                    Double i = Double.Parse(filterField.FilterValue ?? "0.0");
                                    Expression right = Expression.Constant(i, typeof(double));
                                    final = Expression.LessThan(left, right);
                                    break;
                                }
                        }
                        break;
                    }
               
                case "system.int32, mscorlib, version=4.0.0.0, culture=neutral, publickeytoken=b77a5c561934e089":
                    {
                        switch (filterField.FilterOperator)
                        {
                            case FilterOperator.EQUALS:
                                {

                                    Expression left = CreateExpression(_type, filterField.Field.ApplicationEntityProperty.Name, pe);
                                    Expression right = null;
                                    if (filterField.Field.ApplicationEntityProperty.IsNullable)
                                    {
                                        if (String.IsNullOrEmpty(filterField.FilterValue))
                                        {
                                            right = Expression.Constant(null, typeof(int?));
                                        }
                                        else
                                        {
                                            Int32 i = Int32.Parse(filterField.FilterValue);
                                            right = Expression.Constant(i, typeof(int?));
                                        }
                                    }
                                    else
                                    {
                                        Int32 i = Int32.Parse(filterField.FilterValue);
                                        right = Expression.Constant(i, typeof(int));
                                    }
                                    final = Expression.Equal(left, right);
                                    break;
                                }
                            case FilterOperator.GREATER_THAN:
                                {
                                    Expression left = CreateExpression(_type, filterField.Field.ApplicationEntityProperty.Name, pe); // Expression.Property(pe, _type.GetProperty(property));

                                    Int32 i = Int32.Parse(filterField.FilterValue);
                                    Expression right = Expression.Constant(i, typeof(int));
                                    final = Expression.GreaterThan(left, right);
                                    break;
                                }
                            case FilterOperator.LESS_THAN:
                                {
                                    Expression left = Expression.Property(pe, _type.GetProperty(filterField.Field.ApplicationEntityProperty.Name));
                                    Int32 i = Int32.Parse(filterField.FilterValue);
                                    Expression right = Expression.Constant(i, typeof(int));
                                    final = Expression.LessThan(left, right);
                                    break;
                                }
                        }
                        break;
                    }

                case "system.boolean, mscorlib, version=4.0.0.0, culture=neutral, publickeytoken=b77a5c561934e089":
                    {
                        switch (filterField.FilterOperator)
                        {
                            case FilterOperator.EQUALS:
                                {
                                    Expression left = Expression.Property(pe, _type.GetProperty(filterField.Field.ApplicationEntityProperty.Name));
                                    Boolean i = Boolean.Parse(filterField.FilterValue ?? true.ToString());
                                    Expression right = Expression.Constant(i, typeof(bool));
                                    final = Expression.Equal(left, right);
                                    break;
                                }
                            case FilterOperator.NOT_EQUALS:
                                {
                                    Expression left = Expression.Property(pe, _type.GetProperty(filterField.Field.ApplicationEntityProperty.Name));
                                    Boolean i = Boolean.Parse(filterField.FilterValue ?? true.ToString());
                                    Expression right = Expression.Constant(i, typeof(bool));
                                    final = Expression.GreaterThan(left, right);
                                    break;
                                }
                        }
                        break;
                    }
            }
            return final;
        }

        public static Expression<Func<T, TReturn>> GetSelector<T, TReturn>(string fieldName) where T : class  where TReturn : class
        {
            var t = typeof(TReturn);
            ParameterExpression p = Expression.Parameter(typeof(T), "t");
            var body = Expression.Property(p, fieldName);
            return Expression.Lambda<Func<T, TReturn>>(body, new ParameterExpression[] { p });
        }

        public Expression GetSelectExpression<T>(ParameterExpression pe, FilterField filterField)
        {
            Expression final = null;
            Type _type = typeof(T);
            switch (filterField.Field.ApplicationEntityProperty.type.ToLower())
            {
                case "system.string, mscorlib, version=4.0.0.0, culture=neutral, publickeytoken=b77a5c561934e089":
                    {
                        switch (filterField.FilterOperator)
                        {
                            case FilterOperator.EQUALS:
                                {
                                    Expression left = Expression.Property(pe, _type.GetProperty(filterField.Field.ApplicationEntityProperty.Name));
                                    Expression right = Expression.Constant(filterField.FilterValue);
                                    final = Expression.Equal(left, right);
                                    break;
                                }
                            case FilterOperator.CONTAINS:
                                {
                                    if (String.IsNullOrEmpty(filterField.FilterValue))
                                    {
                                        final = Expression.Constant(true); ;
                                    }
                                    else
                                    {
                                        Expression right = Expression.Constant(filterField.FilterValue ?? String.Empty);
                                        Expression zero = Expression.Constant(0);

                                        Type t = _type.GetProperty(filterField.Field.ApplicationEntityProperty.Name).PropertyType;
                                        MethodInfo methodInfo = t.GetMethod("IndexOf", new Type[] { typeof(string) });

                                        //                                    Expression _property = Expression.Property(Expression.Parameter(_type, "_obj"), filterField.Field.ApplicationEntityProperty.Name);
                                        Expression _property = Expression.Property(pe, filterField.Field.ApplicationEntityProperty.Name);
                                        //                                    Expression lambda = Expression.Lambda(_property, Expression.Parameter(_type, "x"));

                                        Expression left = Expression.Call(_property, methodInfo, right);
                                        //Expression left = Expression.Call(pe,methodInfo, right);
                                        final = Expression.GreaterThanOrEqual(left, zero);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
            return final;
        }

/*        static Expression CreateExpression(Type type, string propertyName, ParameterExpression pe)
        {
            var param = pe; //Expression.Parameter(type, "x");
            Expression body = param;
            foreach (var member in propertyName.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }
            return body;

        }*/

        public FilterResult<T> GetOffsetResult<T>(IQueryable<T> query, Filter commonFilter, ParameterExpression pe)
        {
            int count = query.Count();

            var type = typeof(T);
            var property = type.GetProperty("Id");

            var propertyAccess = Expression.MakeMemberAccess(pe, property);
            var orderByExpression = Expression.Lambda(propertyAccess, pe);
            var resultExpression = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, property.PropertyType },
                query.Expression, Expression.Quote(orderByExpression));
            IQueryable<T> _result =  (IOrderedQueryable<T>)query.Provider.CreateQuery<TEntity>(resultExpression).AsNoTracking();

            IEnumerable<T> result = _result.
                Skip<T>((commonFilter.PageIndex -1)* commonFilter.PageSize).
                Take<T>(commonFilter.PageSize).ToList<T>();

            return new FilterResult<T>
            {
                Result = result,
                Count = count
            };
        }

        public async Task<FilterResult<T>> GetOffsetResultAsync<T>(IQueryable<T> query, Filter commonFilter)
        {
            int count = await query.CountAsync();
            IEnumerable<T> result = await query.
                Skip(commonFilter.PageIndex * commonFilter.PageSize).
                Take(commonFilter.PageSize).ToListAsync();

            return new FilterResult<T>
            {
                Result = result,
                Count = count
            };
        }

    }
}
