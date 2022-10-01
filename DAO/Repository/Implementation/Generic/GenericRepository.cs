using Common.DAO.Access;
using Common.Enum;
using Common.Exceptions;
using Common.Filter;
using Common.Helper;
using Common.Standard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.BAL.Scripting;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Model.Custom.Scripting;
using SpeedFramework.DAO.Model.Custom.StateMachine;
using SpeedFramework.DAO.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, TEntity
    {
        public IUserContext userContext { get; set; }
        public IAccountContext accountContext { get; set; }
        public IModelContext db { get; set; }
        public DbSet<T> _set { get; set; }
        public IQueryable<T> _accessQualifiedQueryable { get; set; }
        public abstract string entity_name { get; set; }
        public abstract string entity_label { get; set; }

        public abstract Dictionary<string, string> labels { get; set; }

 
        public string _entityName { get; set; }

        public abstract void BeforeNavigationFieldBind(T t);

        private void ValidateAccessQualification(T _obj)
        {
            try
            {
                List<ApplicationEntityAccessExpression> applicationEntityAccessExpressions
                     = db.ApplicationEntityAccessExpressions.Where(m => m.ApplicationEntity.Name == _entityName & !m.Inactive)
                     .ToList();
                foreach (ApplicationEntityAccessExpression ApplicationEntityAccessExpression in applicationEntityAccessExpressions)
                {
                    if (!String.IsNullOrEmpty(ApplicationEntityAccessExpression.PropertyAccessExpresion) && !String.IsNullOrEmpty(ApplicationEntityAccessExpression.ContextAccessExpresion))
                    {
                        int value = Int32.Parse(userContext.preferences.Where(m => m.Item1 == ApplicationEntityAccessExpression.ContextAccessExpresion).FirstOrDefault().Item2);
                        if (value != 0)
                        {
                            OwnershipEntityAccess ownershipEntityAccess = db.OwnershipEntityAccesses.
                                Where(m => m.IntUserId == userContext.CurrentUserId & m.eId == value & m.ApplicationEntity.Name == ApplicationEntityAccessExpression.ApplicationEntity.Name)
                                .FirstOrDefault();
                            if (ownershipEntityAccess == null)
                            {
                                throw new DataProcessingException("Access to this entity is failed for this user.");
                            }
                            else
                            {
                                int propertyValue = Int32.Parse(""+GetPropertyValue(_obj, ApplicationEntityAccessExpression.PropertyAccessExpresion));
                                if (propertyValue != ownershipEntityAccess.eId)
                                {
                                    throw new DataProcessingException("Access to this entity is failed for this user.");
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DataProcessingException("Access to this entity is restricted for this user.");
            }
        }

        private async Task setAccessQualifiedQueryable()
        {
            if (_accessQualifiedQueryable == null)
            {
                FilterEngine fe = new FilterEngine();
                List<ApplicationEntityAccessExpression> applicationEntityAccessExpressions
                     = db.ApplicationEntityAccessExpressions.Where(m => m.ApplicationEntity.Name == _entityName & !m.Inactive)
                     .ToList();
                List<Expression> expressions = new List<Expression>();
                ParameterExpression pe = Expression.Parameter(typeof(T), "_obj");
                foreach (ApplicationEntityAccessExpression ApplicationEntityAccessExpression in  applicationEntityAccessExpressions)
                {

                    if (!String.IsNullOrEmpty(ApplicationEntityAccessExpression.PropertyAccessExpresion) && !String.IsNullOrEmpty(ApplicationEntityAccessExpression.ContextAccessExpresion))
                    {
                        Tuple<string, string> tuple = userContext.preferences.Where(m => m.Item1 == ApplicationEntityAccessExpression.ContextAccessExpresion).FirstOrDefault();
                        int value = Int32.Parse(tuple.Item2);

                        if (value != 0)
                        {
                            OwnershipEntityAccess ownershipEntityAccess = db.OwnershipEntityAccesses.
                                   Where(m => m.IntUserId == userContext.CurrentUserId & (m.eId == value | m.eId == 0) & m.ApplicationEntity.Name == ApplicationEntityAccessExpression.PropertyApplicationEntity.Name)
                                   .FirstOrDefault();
                            if (ownershipEntityAccess != null)
                            {
                                Expression left = FilterEngine.CreateExpression(typeof(T), ApplicationEntityAccessExpression.PropertyAccessExpresion, pe);
                                Expression right = Expression.Constant(value);
                                Expression final = Expression.Equal(left, right);
                                expressions.Add(final);
                            }
                            else
                            {
                                throw new DataProcessingException("Access to this entity is restricted for this user.");
                            }
                        }
                    }
                }
                MethodCallExpression methodCallExpression = fe.GetWhere<T>(_set, expressions, pe);
                _accessQualifiedQueryable = _set.AsQueryable().Provider.CreateQuery<T>(methodCallExpression);
            }
        }
        public GenericRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext)
        {
            _entityName = typeof(T).AssemblyQualifiedName;
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
            _set = db.GetDbContext().Set<T>();
            Getlabels();
        }


        public IEnumerable<StateActionStatement> GetStateActionStatements(int Id)
        {
            ApplicationEntity entity = db.ApplicationEntities.Where(m => m.Name == _entityName).FirstOrDefault();
            return db.StateActionStatements.Where(m => m.ApplicationEntityProperty.ApplicationEntityId == entity.Id & m.UserDefinedRoleId==userContext.CurrentRoleId & !m.Inactive & !m.StateAction.Inactive).ToList();
        }

        public Form GetForm()
        {
            ApplicationEntity entity = db.ApplicationEntities.Where(m => m.Name == _entityName).FirstOrDefault();
            Dignos.CheckException(entity == null, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Entity"));
            //            FormApplicationEntityMap map = db.FormCollectionMaps.Where(m =>  !m.Inactive & m.ApplicationEntity.Name == typeof(T).FullName).FirstOrDefault();
            Form form = db.Forms.Where(m => m.ApplicationEntityId == entity.Id & m.IsPreferred).FirstOrDefault();
            Dignos.CheckException(form == null, StandardMessage.NO_LINK.FormatError("Form", "Entity"));
            return form;
        }



        public async Task<FilterResult<T>> GetUIFiltered(int? Id, string value, IEnumerable<FilterField> filterFields, IUserContext userContext, int s, int n)
        {
            Task task =  setAccessQualifiedQueryable();
            FilterEngine filterEngine = new FilterEngine();            
            ParameterExpression pe = Expression.Parameter(typeof(T), "_obj");
            List<Expression> expressions = new List<Expression>();


            ApplicationEntity applicationEntity = db.ApplicationEntities.Where(o => o.Name == _entityName).FirstOrDefault();
            ApplicationEntityProperty nameProperty = db.ApplicationEntityProperties.Where(o => o.ApplicationEntityId == applicationEntity.Id & o.IncludeInName).FirstOrDefault();
            Field f = new Field();
            db.SetStateAsDetached(f);
            FilterField ff = new FilterField();
            db.SetStateAsDetached(ff);

            f.ApplicationEntityProperty = nameProperty;
            f.ApplicationEntityPropertyId = nameProperty.Id;
            ff.Field = f;
            ff.FieldId = f.Id;
            ff.FilterValue = value;
            ff.FilterOperator = FilterOperator.CONTAINS;


            Expression _e = filterEngine.GetWhereExpression<T>(pe, ff, userContext);
            expressions.Add(_e);
            await task;
            MethodCallExpression _m = filterEngine.GetWhere<T>(_accessQualifiedQueryable, expressions, pe);
            IQueryable<T> _results = _accessQualifiedQueryable.Provider.CreateQuery<T>(_m);

            FilterResult<T> filterResult = null;
            Filter filter = null;
            if (Id.HasValue && Id != 0)
            {
                filter = db.Filters.Where(o => o.Id == Id).FirstOrDefault();
                IEnumerable<FilterField> fields = db.FilterFields.Where(o => o.CommonFilter.Id == filter.Id).ToList();

                IQueryable<T> results = null;



                foreach (FilterField field in fields)
                {
                    if (filterFields.Select(x => x.Id).ToList().Contains(field.Id))
                    {
                        if (field.LockValue)
                        {
                            Expression e = filterEngine.GetWhereExpression<T>(pe, field, userContext);
                            expressions.Add(e);
                        }
                        else
                        {
                            field.FilterValue = filterFields.Where(x => x.Id == field.Id).FirstOrDefault().FilterValue;
                            Expression e = filterEngine.GetWhereExpression<T>(pe, field, userContext);
                            expressions.Add(e);
                        }
                    }

                }

                MethodCallExpression m = filterEngine.GetWhere<T>(_results, expressions, pe);
                results = _results.Provider.CreateQuery<T>(m);
                filter.PageSize = s;
                filter.PageIndex = n;

                filterResult = filterEngine.GetOffsetResult(results, filter, pe);
                return filterResult;
            }
            filter = new Filter() {
            PageSize = s,
            PageIndex = n
            };
            filterResult = filterEngine.GetOffsetResult(_results, filter, pe);
            return filterResult;
        }


        public FilterResult<T> GetFiltered(int Id, IEnumerable<FilterField> filterFields, IUserContext userContext, int s, int n)
        {
            setAccessQualifiedQueryable();
            Filter filter = db.Filters.Where(o => o.Id == Id).FirstOrDefault();
            FilterEngine filterEngine = new FilterEngine();

            IEnumerable<FilterField> fields = db.FilterFields.Where(o => o.CommonFilter.Id == filter.Id).ToList();

            IQueryable<T> results = null;
            List<Expression> expressions = new List<Expression>();
            ParameterExpression pe = Expression.Parameter(typeof(T), "_obj");

            foreach (FilterField field in fields)
            {
                if (filterFields.Select(x => x.Id).ToList().Contains(field.Id))
                {
                    if (field.LockValue)
                    {
                        Expression e = filterEngine.GetWhereExpression<T>(pe, field, userContext);
                        expressions.Add(e);
                    }
                    else
                    {
                        field.FilterValue = filterFields.Where(x => x.Id == field.Id).FirstOrDefault().FilterValue;
                        Expression e = filterEngine.GetWhereExpression<T>(pe, field, userContext);
                        expressions.Add(e);
                    }
                }

            }

            MethodCallExpression m = filterEngine.GetWhere<T>(_accessQualifiedQueryable, expressions, pe);
            results = _accessQualifiedQueryable.Provider.CreateQuery<T>(m);
            filter.PageSize = s;
            filter.PageIndex = n;

            FilterResult<T>  filterResult = filterEngine.GetOffsetResult(results, filter, pe);

            return filterResult;
        }

        public void CheckDuplicate(T t, Expression<Func<T, bool>> dupQuery)
        {
            if (t.Id == 0)
            {
                int c = _set.Where(dupQuery).Count();
                Dignos.CheckException(c > 0, StandardMessage.ERR_DUPLICATE_RECORD.FormatError(entity_label));
            }
            else
            {
                int c = _set.Where(dupQuery).Where(m=>m.Id == t.Id).Count();
                int _c = _set.Where(dupQuery).Where(m => m.Id != t.Id).Count();

                Dignos.CheckException(c + _c > 1, StandardMessage.ERR_DUPLICATE_RECORD.FormatError(entity_label));
            }
        }

        public void Getlabels()
        {

            //LabelRepository LabelRepository = new LabelRepository(db);

           // entity_label = LabelRepository.GetLabel(entity_name);
           // foreach (string name in labels.Keys.ToList())
            {
            //    labels[name] = LabelRepository.GetLabel(name);
            }
        }

        public IEnumerable<T> GetAll()
        {
            setAccessQualifiedQueryable().Wait();
            return _accessQualifiedQueryable.AsNoTracking().ToList();
        }


        public ApplicationEntity GetEntity()
        {
            ApplicationEntity applicationEntity = db.ApplicationEntities.Where(m => m.Name == _entityName).FirstOrDefault();
            return applicationEntity;
        }

        public T Get(int Id)
        {
            setAccessQualifiedQueryable();
            T pb = _accessQualifiedQueryable.Where(m => m.Id == Id).FirstOrDefault();
            Dignos.CheckException(pb == null, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError(entity_label));
            return  pb;
        }

        public T Get(string name)
        {
            setAccessQualifiedQueryable();

            ApplicationEntityProperty Nameproperty = db.ApplicationEntityProperties.Where(m => m.ApplicationEntity.Name == this._entityName & m.IncludeInName).FirstOrDefault();

            ParameterExpression pe = Expression.Parameter(typeof(T), "_obj");
            Expression left = Expression.Property(pe, typeof(T).GetProperty(Nameproperty.Name));
            Expression right = Expression.Constant(name);
            Expression final = Expression.Equal(left, right);

            Expression.Lambda<Func<T, bool>>(final, pe);
            T pb = _accessQualifiedQueryable.Where(Expression.Lambda<Func<T, bool>>(final, pe)).FirstOrDefault();
            Dignos.CheckException(pb == null, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError(entity_label));
            return pb;
        }





        public int Add(T _object)
        {
            Validate(_object);
            BeforeNavigationFieldBind(_object);
            GetNavigationProperties(_object);
            BeforeAdd(_object);
            
            ApplicationEntity Entity = db.ApplicationEntities.Where(m => m.Name == _entityName).FirstOrDefault();
            IEnumerable<EntityScript> before_script = db.EntityScripts.Where(m => m.ApplicationEntity.Name == _entityName & !m.Inactive & m.SubmitEventType==SubmitEventType.BEFORE_ADD).ToList();
            foreach (EntityScript s in before_script)
            {
                ScriptEngine.Execute(new { payload = _object, db },s.Script.Text);
            }
            IntUser user = db.IntUsers.Where(m => m.Id == userContext.CurrentUserId).FirstOrDefault();
        //    Auditable.MarkCreatedDate(_object, user);
            _set.Add(_object);
            db.SaveChanges();


            if (!String.IsNullOrEmpty(Entity.NumberFormat))
            {
                _object.ApplicationNumber = Entity.Prefix + _object.Id.ToString(Entity.NumberFormat) + Entity.Postfix;
            }
            else
            {
                _object.ApplicationNumber = Entity.Prefix + _object.Id + Entity.Postfix;
            }

            db.SetStateAsModified(_object);

            db.SaveChanges();
            IEnumerable <EntityScript> after_script = db.EntityScripts.Where(m => m.ApplicationEntity.Name == _entityName & !m.Inactive & m.SubmitEventType == SubmitEventType.AFTER_ADD).ToList();
            foreach (EntityScript s in after_script)
            {
                ScriptEngine.Execute(new { payload = _object, db }, s.Script.Text);
            }
            AfterAdd(_object);
            return _object.Id;
        }



        public bool Delete(int Id)
        {

            T _object = _set.Where(m => m.Id == Id).FirstOrDefault();
            IntUser user = db.IntUsers.Where(m => m.Id == userContext.CurrentUserId).FirstOrDefault();
           // Auditable.MarkDeletedDate(_object, user);
            db.SaveChanges();
            return true;
        }


/*        IDictionary<string, object> GetKeyValues<T>(DbContext db,
                                            T entity) where T : class
        {
            var oc = ((IObjectContextAdapter)db).ObjectContext;
            IDictionary<string, object> m =
             oc.ObjectStateManager.GetObjectStateEntry(entity).EntityKey.EntityKeyValues
                                           .ToDictionary(x => x.Key, y => y.Value);
            return m;
        }*/

        public Dictionary<PropertyInfo, PropertyInfo> GetNavigationProperties(T entity)
        {
            Dictionary<PropertyInfo, PropertyInfo> g = new Dictionary<PropertyInfo, PropertyInfo>();
            List<System.Reflection.PropertyInfo> properties = new List<System.Reflection.PropertyInfo>();
            Type entityType = entity.GetType();
          //  MetadataWorkspace workspace = ((IObjectContextAdapter)this.db).ObjectContext.MetadataWorkspace;
           // ObjectItemCollection itemCollection = (ObjectItemCollection)(workspace.GetItemCollection(DataSpace.OSpace));
           // EntityType _entityType = itemCollection.OfType<EntityType>().Single(e => itemCollection.GetClrType(e) == typeof(T));
            List<IEntityType> _entityTypes = db.GetDbContext().Model.GetEntityTypes().ToList();
            IEntityType _entityType = _entityTypes.SingleOrDefault(m => m.ClrType == typeof(T));
            var entitySetElementType = _entityType;
            List<INavigation> navigations = _entityType.GetNavigations().ToList();
//            navigations.FirstOrDefault().`
            //
             foreach (var navigationProperty in navigations) //entitySetElementType.NavigationProperties)
            {
                PropertyInfo navProperty = entityType.GetProperty(navigationProperty.Name);
                properties.Add(navProperty);
                PropertyInfo propertyInfo = entity.GetType().GetProperties().Where(m => m.Name == navigationProperty.Name + "Id").FirstOrDefault();
                g.Add(propertyInfo, navProperty);
                var _enclosedType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
                int i = 0;
                if (_enclosedType != null)
                {
                    int? e_i = (int?)entity.GetType().GetProperty(propertyInfo.Name).GetValue(entity);
                    if (e_i.HasValue)
                    {
                        i = e_i.Value;
                        object k = db.GetDbContext().Set<T>(navProperty.PropertyType.AssemblyQualifiedName).Find(i);
                        Dignos.CheckException(k == null, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError(navProperty.Name));
                        entity.GetType().GetProperty(navProperty.Name).SetValue(entity, k);
                    }
                }
                else
                {
                    int? e_i = (int?)entity.GetType().GetProperty(propertyInfo.Name).GetValue(entity);
                    if (e_i.HasValue)
                    {
                        i = e_i.Value;
                        object k = db.GetDbContext().Set<T>(navProperty.PropertyType.AssemblyQualifiedName).Find(i);
                        Dignos.CheckException(k == null, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError(navProperty.Name));
                        entity.GetType().GetProperty(navProperty.Name).SetValue(entity, k);
                    }
               }
                
            }

            return g;
        }

   




        private List<string> findTags(string s)
        {
            HashSet<string> sets = new HashSet<string>();
            string[] d = s.Split(new[] { "${o." }, StringSplitOptions.None);
            for (int i = 0; i < d.Length; i++)
            {

                if (!String.IsNullOrEmpty(d[i]))
                {
                    int k = d[i].IndexOf("}");
                    if (k > 0)
                    {

                        sets.Add("${o." + d[i].Substring(0, k) + "}");
                    }
                }

            }
            return sets.ToList();
        }

        public static object GetPropertyValue(object src, string propName)
        {
            if (src == null) throw new ArgumentException("Value cannot be null.", "src");
            if (propName == null) throw new ArgumentException("Value cannot be null.", "propName");

            if (propName.Contains("."))//complex type nested
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
            }
            else
            {
                var prop = src.GetType().GetProperty(propName);
                return prop?.GetValue(src, null);
            }
        }

        public string Print(int templateId, int oId)
        {
            CommunicationTemplate template = db.CommunicationTemplates.Where(m => m.Id == templateId).FirstOrDefault();
            if (template.CommunicationType.Name == "Print")
            {
                T t = db.GetDbContext().Set<T>().Where(m => m.Id == oId).FirstOrDefault();



                string printText = template.Text;
                string printSubject = template.Subject;
                List<string> sub_matches = findTags(printSubject);
                List<string> text_matches = findTags(printText);

                foreach (string match in sub_matches)
                {
                    try
                    {
                        string _match = match.Replace("${o.", String.Empty);
                        _match = _match.Replace("}", String.Empty);
                        string _value = "" + GetPropertyValue(t, _match);
                        printSubject = printSubject.Replace(match, _value);

                    }
                    catch (Exception e)
                    {
                    }
                }
                foreach (string match in text_matches)
                {
                    try
                    {
                        string _match = match.Replace("${o.", String.Empty);
                        _match = _match.Replace("}", String.Empty);
                        string _value = "" + GetPropertyValue(t, _match);
                        printText = printText.Replace(match, _value);
                    }
                    catch (Exception e)
                    {
                    }
                }

                string PDF_PATH = ""; //Configuration.AppSettings["PDF_PATH"].ToString();
                string path = PDF_PATH + typeof(T).Name + "_" + oId + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".pdf";
                PrintHelper.Print<T>(printText, t, path);
                return path;
            }
            else
            {
                throw new DataProcessingException(StandardMessage.ERR_ENTITY_INVALID.FormatError("Tempalate"));
            }
        }


        private void Communicate(int templateId, int oId, IAccountContext accountContext)
        {
            
            ModelContext db = new ModelContext(accountContext);
            CommunicationTemplate template = db.CommunicationTemplates.Where(m => m.Id == templateId).FirstOrDefault();
            List<string> users = db.CommunicationTemplateUserRecieverMaps.Where(m => !m.Inactive & m.CommunicationTemplateId == templateId).Select(m => m.To.Email).Distinct().ToList();
            List<int> roleids = db.CommunicationTemplateRoleRecieverMaps.Where(m => !m.Inactive & m.CommunicationTemplateId == templateId).Select(m => m.ToId).Distinct().ToList();
            List<string> _users = db.UserDefinedRoleToUserMaps.Where(m => !m.Inactive & roleids.Contains(m.RoleId.Value)).Select(m => m.IntUser).Distinct().Select(m=>m.Email).Distinct().ToList();
            users.AddRange(_users);
            users = users.Distinct().ToList();
            if (template.CommunicationType.Name == "Email")
            {
                T t = db.Set<T>().Where(m => m.Id == oId).FirstOrDefault();
                string emailText = template.Text;
                string emailSubject = template.Subject;
                List<string> sub_matches = findTags(emailSubject);
                List<string> text_matches = findTags(emailText);

                foreach (string match in sub_matches)
                {
                    try
                    {
                        string _match = match.Replace("${o.",String.Empty);
                        _match = _match.Replace("}", String.Empty);
                        string _value = "" + GetPropertyValue(t, _match);
                        emailSubject = emailSubject.Replace(match, _value);

                    }
                    catch (Exception e)
                    {
                    }
                }
                foreach (string match in text_matches)
                {
                    try
                    {
                        string _match = match.Replace("${o.", String.Empty);
                        _match = _match.Replace("}", String.Empty);
                        string _value = "" + GetPropertyValue(t, _match);
                        emailText = emailText.Replace( match , _value);
                    }
                    catch (Exception e)
                    {
                    }
                }

                db.Dispose();

                string smtpurl = "smtp.gmail.com";
                int port = 587;
                string From = ""; //new Configuration(). ConfigurationManager.AppSettings["SYSTEMEMAIL"].ToString();
                string userName = ""; // ConfigurationManager.AppSettings["SMTPUSER"].ToString();
                string password = ""; // ConfigurationManager.AppSettings["SMTPPWD"].ToString();
                string _to = String.Empty;
                for (int i = 0; i < users.Count; i++)
                {
                    if (i == users.Count - 1)
                    {
                        _to += users[i];
                    }
                    else
                    {
                        _to += users[i] + ",";
                    }
                }
                EmailHelper.Email(From, _to, emailSubject, emailText, userName, password, smtpurl, port);

            }
        }

        public string StandardParse(string value)
        {
            switch (value)
            {
                case "${DateObject.Now}":
                {
                    value = DateTime.Now.ToString();
                    break;
                }
                case "${Current.userid}":
                {
                    value = ""+this.userContext.CurrentUserId;
                    break;
                }
                case "${Current.roleid}":
                {
                        value = ""+this.userContext.CurrentRoleId;
                        break;
                }
            }
            return value;
        }

        public bool StandardCompare(string currentValue, string obj_value)
        {
            switch (currentValue)
            {
                case "${*}":
                    {
                        return true;

                    }
                case "${null}":
                    {
                        return obj_value=="";

                    }
                case "${notnull}":
                    {
                        return obj_value != "";

                    }
                default :
                    {
                        return currentValue == "" + obj_value;

                    }
            }
        }

        public bool EditAction(T _object, int Id)
        {
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();
            IEnumerable<StateActionStatement> actionStatement = GetStateActionStatements(_object.Id).Where(m=>m.StateActionId==Id).ToList();
            T obj = _set.Where(m => m.Id == _object.Id).FirstOrDefault();
            foreach (StateActionStatement p in actionStatement)
            {
                PropertyInfo propertyInfo = _object.GetType().GetProperty(p.ApplicationEntityProperty.Name);

                object obj_value = propertyInfo.GetValue(obj,null);
                if (StandardCompare(p.currentValue, ""+obj_value))
                {
                    if (p.nextValue != "${nochange}")
                    {
                        string _nextValue = StandardParse(p.nextValue);
                        if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {

                            if (String.IsNullOrEmpty(_nextValue))
                            {
                            }
                            else
                            {
                                propertyInfo.SetValue(_object, Convert.ChangeType(_nextValue, propertyInfo.PropertyType.GetGenericArguments()[0]), null);
                            }
                        }
                        else
                        {
                            propertyInfo.SetValue(_object, Convert.ChangeType(_nextValue, propertyInfo.PropertyType), null);

                        }
                    }
                }
                if (p.CommunicationTemplateId.HasValue & p.CommunicationTemplateId != 0)
                {
                    tuples.Add(new Tuple<int,int>(p.CommunicationTemplateId.Value,_object.Id));
                }
            }

            db.SetStateAsDetached(obj);
            bool result = Edit(_object);
            foreach(Tuple<int,int> tuple in tuples)
            {
                Task.Run(() => Communicate(tuple.Item1, tuple.Item2, this.accountContext)).ConfigureAwait(false);
            }
            return result;
        }


        public bool Edit(T _object)
        {
            Validate(_object);
            ValidateAccessQualification(_object);
            GetNavigationProperties(_object);
            IEnumerable<EntityScript> before_script = db.EntityScripts.Where(m => m.ApplicationEntity.Name == _entityName & !m.Inactive & m.SubmitEventType == SubmitEventType.BEFORE_EDIT).ToList();
            foreach (EntityScript s in before_script)
            {
                ScriptEngine.Execute(new { payload = _object, db }, s.Script.Text);
            }
            db.SetStateAsModified(_object);
            BeforeEdit(_object);
            IntUser user = db.IntUsers.Where(m => m.Id == userContext.CurrentUserId).FirstOrDefault();
         //   Auditable.MarkModifiedDate(_object,db,user);
            db.SaveChanges();
            IEnumerable<EntityScript> after_script = db.EntityScripts.Where(m => m.ApplicationEntity.Name == _entityName & !m.Inactive & m.SubmitEventType == SubmitEventType.AFTER_EDIT).ToList();
            foreach (EntityScript s in after_script)
            {
                ScriptEngine.Execute(new { payload = _object, db }, s.Script.Text);
            }
            AfterEdit(_object);

            return true;
        }

    

        public abstract void Validate(T t);
        public abstract IQueryable<T> GetAccessFilterdSet();

        public abstract void BeforeAdd(T t);
        public abstract void AfterAdd(T t);
        public abstract void BeforeEdit(T t);
        public abstract void AfterEdit(T t);

       

        public IEnumerable<CommunicationTemplate> GetTemplates(int Id)
        {
            ApplicationEntity entity = db.ApplicationEntities.Where(m => m.Name == _entityName).FirstOrDefault();
            return db.CommunicationTemplates.Where(m => m.ApplicationEntityId == entity.Id & !m.Inactive).ToList();
        }
    }

}