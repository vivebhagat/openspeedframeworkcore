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
    public class CommunicationTemplateRepository : GenericActivableRepository<CommunicationTemplate>, ICommunicationTemplateRepository
    {
        public override string entity_name
        {
            get { return "Communication Template"; }
            set { value = "Communication Template"; }
        }
        public override string entity_label
        {
            get { return "Communication Template"; }
            set { value = "Communication Template"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public CommunicationTemplateRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(CommunicationTemplate o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            /*            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

                        CheckDuplicate(o, m => m.Name == o.Name);*/
        }

        public override IQueryable<CommunicationTemplate> GetAccessFilterdSet()
        {
            return _set;
        }


        public IEnumerable<CommunicationTemplate> GetForEntity(int Id)
        {
            return db.CommunicationTemplates.Where(m => m.ApplicationEntityId == Id).ToList();
        }

        public override void BeforeAdd(CommunicationTemplate o)
        {
        }

        public override void AfterAdd(CommunicationTemplate o)
        {

        }

        public override void BeforeEdit(CommunicationTemplate o)
        {
        }

        public override void AfterEdit(CommunicationTemplate o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(CommunicationTemplate t)
        {

        }
    }

}
