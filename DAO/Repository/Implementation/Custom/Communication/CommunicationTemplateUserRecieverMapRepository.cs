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
    public class CommunicationTemplateUserRecieverMapRepository : GenericActivableRepository<CommunicationTemplateUserRecieverMap>, ICommunicationTemplateUserRecieverMapRepository
    {
        public override string entity_name
        {
            get { return "Communication Template User Map"; }
            set { value = "Communication Template User Map"; }
        }
        public override string entity_label
        {
            get { return "Communication Template User Map"; }
            set { value = "Communication Template User Map"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public CommunicationTemplateUserRecieverMapRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(CommunicationTemplateUserRecieverMap o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            /*            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

                        CheckDuplicate(o, m => m.Name == o.Name);*/
        }

        public override IQueryable<CommunicationTemplateUserRecieverMap> GetAccessFilterdSet()
        {
            return _set;
        }

        public IEnumerable<CommunicationTemplateUserRecieverMap> GetForTemplate(int Id)
        {
            return db.CommunicationTemplateUserRecieverMaps.Where(m => m.CommunicationTemplateId == Id).ToList();
        }

        public override void BeforeAdd(CommunicationTemplateUserRecieverMap o)
        {
        }

        public override void AfterAdd(CommunicationTemplateUserRecieverMap o)
        {

        }

        public override void BeforeEdit(CommunicationTemplateUserRecieverMap o)
        {
        }

        public override void AfterEdit(CommunicationTemplateUserRecieverMap o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(CommunicationTemplateUserRecieverMap t)
        {

        }
    }

}
