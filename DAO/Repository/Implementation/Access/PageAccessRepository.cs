using System;
using System.Collections.Generic;
using System.Linq;
using Common.DAO.Access;
using Common.Helper;
using Common.Standard;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class PageAccessRepository : GenericActivableRepository<PageAccess>, IPageAccessRepository
    {
        public override string entity_name
        {
            get { return "Page"; }
            set { value = "Page"; }
        }
        public override string entity_label
        {
            get { return "Page"; }
            set { value = "Page"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }


        public PageAccessRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

        public bool AddToAccess(int pagelinkid, int roleid)
        {
            int lCount = db.PageLinks.Where(m => m.Id == pagelinkid).Count();
            Dignos.CheckException(lCount != 1, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Page Link"));
            int rCount = db.UserDefinedRoles.Where(m => m.Id == roleid).Count();
            Dignos.CheckException(rCount != 1, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Role"));

            PageAccess pa = db.PageAccesses.Where(m => m.RoleId == roleid & m.LinkId == pagelinkid).FirstOrDefault();

            if (pa == null)
            {
                pa = new PageAccess
                {
                    Inactive = false,
                    LinkId = pagelinkid,
                    RoleId = roleid,
                };

                db.SetStateAsAdded(pa);
                db.SaveChanges();
            }
            else
            {
                pa.Inactive = true;
                db.SetStateAsModified(pa);
                db.SaveChanges();
            }

            return true;
        }

        public bool RemoveFromAccess(int roleid, int pagelinkid)
        {
            int lCount = db.PageLinks.Where(m => m.Id == pagelinkid).Count();
            Dignos.CheckException(lCount != 1, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Page Link"));
            int rCount = db.UserDefinedRoles.Where(m => m.Id == roleid).Count();
            Dignos.CheckException(rCount != 1, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Role"));

            PageAccess pa = db.PageAccesses.Where(m => m.RoleId == roleid & m.LinkId == pagelinkid).FirstOrDefault();

            if (pa == null)
            {
                return true;
            }
            else
            {
                pa.Inactive = true;
                db.SetStateAsModified(pa);
                db.SaveChanges();
                return true;
            }
        }


        public IEnumerable<PageAccess> GetPageAccessForRole(int Id)
        {
            return db.PageAccesses.Where(m => m.RoleId == Id).ToList();
        }

        public IEnumerable<PageAccess> GetPageAccess()
        {
            return db.PageAccesses.Where(m => m.RoleId == userContext.CurrentRoleId).ToList();
        }

        public IEnumerable<Tuple<string, string>> GetLinksForPage(string PageName)
        {
            return db.PageAccesses.Where(m => m.Link.pageName == PageName & m.Role.Id == userContext.CurrentRoleId & !m.Inactive).Select(c => new { c.Link.linkName, c.Link.url }).AsEnumerable().Select(m => new Tuple<string, string>(m.linkName, m.url)).ToList();
        }

        public override void Validate(PageAccess o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            CheckDuplicate(o, m => m.LinkId == o.LinkId & m.RoleId == o.RoleId);

        }

        public override IQueryable<PageAccess> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(PageAccess o)
        {
        }

        public override void AfterAdd(PageAccess o)
        {
        }

        public override void BeforeEdit(PageAccess o)
        {

        }

        public override void AfterEdit(PageAccess o)
        {
        }

        public bool CheckLink(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                return false;
            }
            else
            {
                PageAccess pageAccess = db.PageAccesses.Where(m => m.RoleId == this.userContext.CurrentRoleId & !m.Inactive & m.Link.url.ToLower() == url.ToLower()).FirstOrDefault();
                if (pageAccess != null)
                {
                    return true;
                }
            }
            return false;
        }

        public override void BeforeNavigationFieldBind(PageAccess o)
        {
            
        }
    }  

}