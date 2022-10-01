using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class CustomPageLinkRepository : GenericActivableRepository<CustomPageLink>, ICustomPageLinkRepository
    {
        public override string entity_name
        {
            get { return "Custom Page Link"; }
            set { value = "Custom Page Link"; }
        }
        public override string entity_label
        {
            get { return "Custom Page Link"; }
            set { value = "Custom Page Link"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public CustomPageLinkRepository(IModelContext db, IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(CustomPageLink o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.url), StandardMessage.ERR_REQUIRED_FIELD.FormatError("URL"));
            Dignos.CheckException(String.IsNullOrEmpty(o.Type), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Type"));

            CheckDuplicate(o, m => m.url == o.url & m.Type ==o.Type);
        }

        public override IQueryable<CustomPageLink> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(CustomPageLink o)
        {
        }

        public override void AfterAdd(CustomPageLink o)
        {

        }

        public override void BeforeEdit(CustomPageLink o)
        {
        }

        public override void AfterEdit(CustomPageLink o)
        {

        }

        public void Dispose()
        {
        }

        public IEnumerable<CustomPageLink> GetForPage(int Id)
        {
            int _count = db.CustomPages.Where(m => m.Id == Id).Count();
            Dignos.CheckException(_count == 0, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("List"));
            IEnumerable<CustomPageLink> links = db.CustomPageLinks.Where(m => m.CustomPageId == Id).ToList();
            return links;
        }

        public override void BeforeNavigationFieldBind(CustomPageLink t)
        {
            
        }
    }

}
