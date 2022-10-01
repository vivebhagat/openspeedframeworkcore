using Common.DAO.Access;
using Common.Exceptions;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.CQ.Access.PagAccessCQ.Query
{
    public class CheckLinkQuery : IQuery    
    {
        public string url { get; set; }
    }

    public class CheckLinkQueryResult : IResult 
    {
        public bool IsValid { get; set; }
    }

    public class CheckLinkQueryHandler : IQueryHandler<CheckLinkQuery>
    {
        public IUserContext userContext { get; set; }
        public IAccountContext accountContext { get; set; }
        public IModelContext db { get; set; }
        public CheckLinkQueryHandler(IModelContext db, IUserContext userContext, IAccountContext accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

        public  IList<IResult> Handle(CheckLinkQuery checkLinkQuery)
        {
            if (checkLinkQuery == null)
                throw new DataProcessingException(@"Invalid query. The parameter 'url' is missing.");

            var result = new List<IResult>();

            if (String.IsNullOrEmpty(checkLinkQuery.url))
                throw new DataProcessingException(@"Invalid query. The parameter 'url' is missing.");

            PageAccess pageAccess = db.PageAccesses.Where(m => m.RoleId == this.userContext.CurrentRoleId & !m.Inactive & m.Link.url.ToLower() == checkLinkQuery.url.ToLower()).FirstOrDefault();

            if (pageAccess != null)
            {
                return new List<IResult> { new CheckLinkQueryResult {
                    IsValid = true
                }};
            }
            else 
            {
                return new List<IResult> { new CheckLinkQueryResult {
                    IsValid = false
                }};
            }

            return result;
        }
    }
}
