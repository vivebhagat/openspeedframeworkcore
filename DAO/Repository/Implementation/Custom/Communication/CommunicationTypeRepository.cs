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

    public class CommunicationTypeRepository : GenericActivableRepository<CommunicationType>, ICommunicationTypeRepository
    {
        public override string entity_name
        {
            get { return "Communication Type"; }
            set { value = "Communication Type"; }
        }
        public override string entity_label
        {
            get { return "Communication Type"; }
            set { value = "Communication Type"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public CommunicationTypeRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(CommunicationType o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
/*            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name);*/
        }

        public override IQueryable<CommunicationType> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(CommunicationType o)
        {
        }

        public override void AfterAdd(CommunicationType o)
        {

        }

        public override void BeforeEdit(CommunicationType o)
        {
        }

        public override void AfterEdit(CommunicationType o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(CommunicationType t)
        {

        }
    }

}
