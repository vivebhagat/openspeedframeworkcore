using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using System.Reflection;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using Microsoft.EntityFrameworkCore;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class ApplicationEntityRepository : GenericActivableRepository<ApplicationEntity>, IApplicationEntityRepository
    {
        public override string entity_name
        {
            get { return "Custom Entity"; }
            set { value = "Custom Entity"; }
        }
        public override string entity_label
        {
            get { return "Custom Entity"; }
            set { value = "Custom Entity"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };
        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public ApplicationEntityRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }


        public bool LoadEntities()
        {
                IntUser user = db.IntUsers.Where(m => m.Id == userContext.CurrentUserId).FirstOrDefault();
                IList<string> entitiesNames = db.GetClassByTypeNames<TEntity>(db);
                foreach (string e in entitiesNames)
                {
                    int c = db.ApplicationEntities.Where(m => m.Name == e).Count();

                    ApplicationEntity applicationEntity = null;
                    if (c == 0)
                    {
                        applicationEntity = new ApplicationEntity {
                            Name = e,
                            IsStandard = true,
                            CreatedDate = DateTime.Now,
                            CreatedById = userContext.CurrentUserId,
                            CreatedBy = user
                        };
                        db.ApplicationEntities.Add(applicationEntity);
                        db.SaveChanges();
                    }
                    else
                    {
                        applicationEntity = db.ApplicationEntities.Where(m => m.Name == e).FirstOrDefault();
                    }
                    AddProperty(db, e, applicationEntity);
                }
            return true;
        }



        public void AddProperty(IModelContext db, string e, ApplicationEntity applicationEntity)
        {

          /*  List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            List<Type> all_types = new List<Type>();
            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    all_types.AddRange(assembly.GetTypes().ToList());
                } catch (Exception _e)
                {
                }
            }*/

            Type objectType = Type.GetType(e); // all_types.Where(m => m.FullName == e).FirstOrDefault();

            PropertyInfo[] propertyInfos = objectType.GetProperties();

            foreach (PropertyInfo p in propertyInfos)
            {
                int _c = db.ApplicationEntityProperties.Where(m => m.Name == p.Name & m.ApplicationEntityId == applicationEntity.Id).Count();

                IntUser iUser = db.IntUsers.Where(m => m.Id == userContext.CurrentUserId).FirstOrDefault();
                if (_c == 0)
                {
                    ApplicationEntityProperty aep = new ApplicationEntityProperty
                    {
                        IsStandard = true,
                        Name = p.Name,
                        ApplicationEntityId = applicationEntity.Id,
                        ApplicationEntity = applicationEntity,
                        IsNullable = p.PropertyType.IsGenericType && (p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)),
                        type = (p.PropertyType.IsGenericType && (p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))) ? Nullable.GetUnderlyingType(p.PropertyType).AssemblyQualifiedName : p.PropertyType.AssemblyQualifiedName,
                        CreatedById = userContext.CurrentUserId,
                        CreatedBy = iUser,
                        CreatedDate = DateTime.Now,

                    };
                    db.ApplicationEntityProperties.Add(aep);
                    db.SaveChanges();
                }
                else
                {
                    ApplicationEntityProperty aep = db.ApplicationEntityProperties.Where(m => m.Name == p.Name & m.ApplicationEntityId == applicationEntity.Id).FirstOrDefault();
                    aep.IsStandard = true;
                    aep.IsNullable = p.PropertyType.IsGenericType && (p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>));
                    aep.type = (p.PropertyType.IsGenericType && (p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))) ? Nullable.GetUnderlyingType(p.PropertyType).AssemblyQualifiedName : p.PropertyType.AssemblyQualifiedName;
                    aep.ModifiedById = userContext.CurrentUserId;
                    aep.ModifiedBy = iUser;
                    aep.ModifiedDate = DateTime.Now;
                    db.GetDbContext().Entry(aep).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }


        public Form GetPreferredForm(int Id)
        {
            int c = _set.Where(m => m.Id == Id).Count();
            Dignos.CheckException(c == 0, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError(entity_name));
            string name = _set.Where(m => m.Id == Id).FirstOrDefault().Name;
            Form map = db.Forms.Where(m => m.IsPreferred &m.ApplicationEntity.Name == name  & !m.Inactive).FirstOrDefault();
            Dignos.CheckException(map == null, StandardMessage.NO_LINK.FormatError("Form", entity_name));
            Dignos.CheckException(map == null, StandardMessage.NO_LINK.FormatError("Form", entity_name));
            return map;
        }


        public override void Validate(ApplicationEntity o)
        {
            Dignos.CheckException(o==null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name);           
        }

        public override IQueryable<ApplicationEntity> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(ApplicationEntity form)
        {
        }

        public override void AfterAdd(ApplicationEntity t)
        {
        }

        public override void BeforeEdit(ApplicationEntity category)
        {
        }

        public override void AfterEdit(ApplicationEntity t)
        {
         
        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(ApplicationEntity t)
        {
            
        }
    }
}
