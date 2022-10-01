using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class CommunicationTemplateRoleRecieverMapRepository : GenericActivableRepository<CommunicationTemplateRoleRecieverMap>, ICommunicationTemplateRoleRecieverMapRepository
    {
        public override string entity_name
        {
            get { return "Communication Template Role Map"; }
            set { value = "Communication Template Role Map"; }
        }
        public override string entity_label
        {
            get { return "Communication Template Role Map"; }
            set { value = "Communication Template Role Map"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public CommunicationTemplateRoleRecieverMapRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(CommunicationTemplateRoleRecieverMap o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            /*            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

                        CheckDuplicate(o, m => m.Name == o.Name);*/
        }

        public override IQueryable<CommunicationTemplateRoleRecieverMap> GetAccessFilterdSet()
        {
            return _set;
        }

        public IEnumerable<CommunicationTemplateRoleRecieverMap> GetForTemplate(int Id)
        {
            return db.CommunicationTemplateRoleRecieverMaps.Where(m => m.CommunicationTemplateId == Id).ToList();
        }


        public override void BeforeAdd(CommunicationTemplateRoleRecieverMap o)
        {
        }

        public override void AfterAdd(CommunicationTemplateRoleRecieverMap o)
        {

        }

        public override void BeforeEdit(CommunicationTemplateRoleRecieverMap o)
        {
        }

        public override void AfterEdit(CommunicationTemplateRoleRecieverMap o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(CommunicationTemplateRoleRecieverMap t)
        {

        }
    }

}
