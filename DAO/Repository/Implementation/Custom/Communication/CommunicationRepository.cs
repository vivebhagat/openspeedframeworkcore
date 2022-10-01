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
    public class CommunicationRepository : GenericRepository<Communication>, ICommunicationRepository
    {
        public override string entity_name
        {
            get { return "Communication"; }
            set { value = "Communication"; }
        }
        public override string entity_label
        {
            get { return "Communication"; }
            set { value = "Communication"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public CommunicationRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) :base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(Communication o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
/*            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name);*/
        }

        public override IQueryable<Communication> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(Communication o)
        {
        }

        public override void AfterAdd(Communication o)
        {

        }

        public override void BeforeEdit(Communication o)
        {
        }

        public override void AfterEdit(Communication o)
        {

        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(Communication t)
        {

        }
    }

}
