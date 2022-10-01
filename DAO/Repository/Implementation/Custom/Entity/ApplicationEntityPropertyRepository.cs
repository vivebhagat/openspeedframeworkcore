using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class ApplicationEntityPropertyRepository : GenericRepository<ApplicationEntityProperty>, IApplicationEntityPropertyRepository
    {
        public override string entity_name
        {
            get { return "Entity Property"; }
            set { value = "Entity Property"; }
        }

        public override string entity_label
        {
            get { return "Entity Property"; }
            set { value = "Entity Property"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public ApplicationEntityPropertyRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }


        public override void Validate(ApplicationEntityProperty o)
        {
            Dignos.CheckException(o==null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));
            int count = db.ApplicationEntities.Where(m => m.Id == o.ApplicationEntityId & !m.Inactive).Count();
            Dignos.CheckException(count == 0,StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Entity"));
            CheckDuplicate(o, m => m.Name == o.Name & m.ApplicationEntityId == o.ApplicationEntityId);           
        }

        public override IQueryable<ApplicationEntityProperty> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(ApplicationEntityProperty form)
        {
        }

        public override void AfterAdd(ApplicationEntityProperty t)
        {

        }

        public override void BeforeEdit(ApplicationEntityProperty category)
        {
        }

        public override void AfterEdit(ApplicationEntityProperty t)
        {
         
        }

        public void Dispose()
        {
        }

        public IEnumerable<ApplicationEntityProperty> GetForApplicationEntity(int Id)
        {
            int c = db.ApplicationEntities.Where(m => m.Id == Id).Count();
            Dignos.CheckException(c==0, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Entity"));

            IEnumerable<ApplicationEntityProperty> aep = db.ApplicationEntityProperties.Where(m => m.ApplicationEntityId == Id).ToList();
            return aep;
        }

        public override void BeforeNavigationFieldBind(ApplicationEntityProperty t)
        {
            
        }
    }
 }
