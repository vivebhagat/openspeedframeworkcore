using Common.DAO.Access;
using Common.Exceptions;
using MediatR;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.CQ.Access.OrganizationCQ.Query
{
    public class GetDefaultOrganizationQuery : IQuery    
    {
        public string url { get; set; }
    }

    public class GetDefaultOrganizationResult : IResult 
    {
        public bool IsValid { get; set; }
    }

    public class GetDefaultOrganizationQueryHandler : IQueryHandler<GetDefaultOrganizationQuery>
    {
        public IUserContext userContext { get; set; }
        public IAccountContext accountContext { get; set; }
        public IModelContext db { get; set; }
        private IMediator mediator { get; set; }
        public GetDefaultOrganizationQueryHandler(IModelContext db, IUserContext userContext, IAccountContext accountContext, IMediator mediator)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
            this.mediator = mediator;
        }

        public IList<IResult> Handle(GetDefaultOrganizationQuery checkLinkQuery)
        {
            if (checkLinkQuery == null)
                throw new DataProcessingException(@"Invalid query. The parameter 'url' is missing.");

            var result = new List<IResult>();

            if (String.IsNullOrEmpty(checkLinkQuery.url))            
                throw new DataProcessingException(@"Invalid query. The parameter 'url' is missing.");

            PageAccess pageAccess = db.PageAccesses.Where(m => m.RoleId == this.userContext.CurrentRoleId & !m.Inactive & m.Link.url.ToLower() == checkLinkQuery.url.ToLower()).FirstOrDefault();
            
            if (pageAccess != null)
            {
                return new List<IResult> {new GetDefaultOrganizationResult { IsValid = true} };
            }
            
            mediator.Publish()
            return result;
        }
    }
}
