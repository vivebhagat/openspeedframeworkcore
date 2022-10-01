using System;
using System.Collections.Generic;
using System.Linq;
using Common.DAO.Access;
using Common.Helper;
using Common.Standard;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class PageLinkRepository : GenericActivableRepository<PageLink>, IPageLinkRepository
    {

        string _entity_name = "Page Link";
        string _entity_label = "Page Link";

        public override string entity_name
        {
            get { return _entity_name; }
            set { value = _entity_name; }
        }

        public override string entity_label
        {
            get { return _entity_label; }
            set { value = _entity_label; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }


        public PageLinkRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }



        public override void Validate(PageLink o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(string.IsNullOrEmpty(o.pageName), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Page Name"));
            Dignos.CheckException(string.IsNullOrEmpty(o.linkName), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Link Name"));
            Dignos.CheckException(string.IsNullOrEmpty(o.url), StandardMessage.ERR_REQUIRED_FIELD.FormatError("URL"));

            CheckDuplicate(o, m => m.linkName == o.linkName & m.pageName == o.pageName);
        }

        public bool LoadUILinks(IList<Tuple<string, string>> result)
        {
            foreach (Tuple<string, string> tuple in result)
            {
                int count = db.PageLinks.Where(m => m.url.ToLower() == "/" + tuple.Item1.ToLower() + "/" + tuple.Item2.ToLower()).Count();
                if (count == 0)
                {
                    IntUser intUser = db.IntUsers.Where(m => m.Id == userContext.CurrentUserId).FirstOrDefault();
                    PageLink p = new PageLink { url = "/" + tuple.Item1.ToLower() + "/" + tuple.Item2.ToLower(),
                        linkName = tuple.Item1 + " > " + tuple.Item2,
                        pageName = "_",
                        CreatedDate = DateTime.Now,
                        CreatedById = userContext.CurrentUserId,
                        CreatedBy = intUser
                    };
                    db.PageLinks.Add(p);
                    db.SaveChanges();
                }
            }
            return true;
        }

        public override IQueryable<PageLink> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(PageLink t)
        {
        }

        public override void AfterAdd(PageLink t)
        {
        }

        public override void BeforeEdit(PageLink t)
        {
        }

        public override void AfterEdit(PageLink t)
        {
        }

        public override void BeforeNavigationFieldBind(PageLink t)
        {
        }
    }
}