using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using System;
using System.ComponentModel;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class WidgetDataRepository : GenericActivableRepository<WidgetData>, IWidgetDataRepository
    {
        public override string entity_name
        {
            get { return "Widget Data"; }
            set { value = "Widget Data"; }
        }
        public override string entity_label
        {
            get { return "Widget Data"; }
            set { value = "Widget Data"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public WidgetDataRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

        public string PreProcess(string query)
        {
            if (!String.IsNullOrEmpty(query))
            {
                query = query.Replace("{CURRENT_USER}", userContext.CurrentUserId.ToString());
                query = query.Replace("{CURRENT_ROLE}", userContext.CurrentRoleId.ToString());
                return query;
            }

            throw new DataProcessingException("Query string is not valid.");
        }

        public Dictionary<string, object> GetWidgetData(int Id, int widgetId)
        {
            Dictionary<string, Dictionary<string, Type>> widgetTypeMap = new Dictionary<string, Dictionary<string, Type>>();
            widgetTypeMap.Add("KPI", new Dictionary<string, Type>() { {"Count", typeof(int)} });
            widgetTypeMap.Add("GAUGE", new Dictionary<string, Type>() {
                { "Min", typeof(int) },
                { "Max", typeof(int) },
                { "Value", typeof(int) },
            });
            widgetTypeMap.Add("TEXT", new Dictionary<string, Type>() {
                { "Text", typeof(string) }
            });

            widgetTypeMap.Add("TABLE", new Dictionary<string, Type>() {
                  { "HEADER", typeof(string[]) },
                { "DATA", typeof(List<List<object>>) },
            });

            widgetTypeMap.Add("BARCHART", new Dictionary<string, Type>() {
                  { "HEADER", typeof(string[]) },
                { "DATA", typeof(List<List<object>>) },
            });

            IEnumerable<WidgetParameter> widgetParameters = db.WidgetParameters.Where(m => m.WidgetDataId == Id).ToList();
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            string WidgetType = db.Widgets.Where(m => m.Id == widgetId).FirstOrDefault().WidgetType.Name;
            Dictionary<string, Type> typeMap = widgetTypeMap.Where(m => m.Key == WidgetType).FirstOrDefault().Value;



            foreach (WidgetParameter widgetParameter in widgetParameters)
            {
                Type t = typeMap.Where(m => m.Key == widgetParameter.Name).FirstOrDefault().Value;

                if (widgetParameter.WidgetParameterType.Name == "Query")
                {
                    if (t == typeof(List<List<object>>))
                    {

                        db.GetDbContext().Database.GetDbConnection().Open();
                        var cmd = db.GetDbContext().Database.GetDbConnection().CreateCommand();
                        cmd.CommandText = PreProcess(widgetParameter.Expression);                        

                        List<List<object>> items = new List<List<object>>();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var item = new List<Object>();
                            items.Add(item);

                            for (int i = 0; i < reader.FieldCount; i++)
                                item.Add(reader[i]);
                        }
                        keyValuePairs.Add(widgetParameter.Name, items);
                        db.GetDbContext().Database.GetDbConnection().Close();

                    }
                    else
                    {
                        DbCommand query = db.GetDbContext().Database.GetDbConnection().CreateCommand();
                        query.CommandText = PreProcess(widgetParameter.Expression);
                        dynamic result = query.ExecuteScalar();

                       // SqlQuery(t, PreProcess(widgetParameter.Expression));
                       // dynamic value = query.ToListAsync().Result.First();
                        keyValuePairs.Add(widgetParameter.Name, result);
                    }

                }
                if (widgetParameter.WidgetParameterType.Name == "Constants")
                {
                    if (t == typeof(string[]))
                    {
                        dynamic value = widgetParameter.Expression.Split(',');
                        keyValuePairs.Add(widgetParameter.Name, value);
                    }
                    else
                    {
                        TypeConverter typeConverter = TypeDescriptor.GetConverter(t);
                        dynamic value = typeConverter.ConvertFromString(widgetParameter.Expression);
                        keyValuePairs.Add(widgetParameter.Name, value);
                    }
                }


            }
            return keyValuePairs;
        }


        public override void Validate(WidgetData o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
        }

        public override IQueryable<WidgetData> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(WidgetData o)
        {
        }

        public override void AfterAdd(WidgetData o)
        {

        }

        public override void BeforeEdit(WidgetData o)
        {
        }

        public override void AfterEdit(WidgetData o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(WidgetData t)
        {
        }
    }

}
