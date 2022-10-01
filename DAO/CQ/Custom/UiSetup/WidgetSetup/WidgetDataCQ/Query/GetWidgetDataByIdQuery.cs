using Common.DAO.Access;
using Common.Exceptions;
using SpeedFramework.DAO.Commmon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.CQ.Custom.UiSetup.Widget.WidgetDataCQ.Query
{
    public class GetDefaultOrganizationtQuery : IQuery    
    {
    }

    public class DefaultOrgnizationResult: IResult 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Inactive { get; set; }
        public bool IsParent { get; set; }
    }

    public class GetDefaultOrganizationQuerydHandler : IQueryHandler<GetDefaultOrganizationtQuery>
    {
        public IUserContext userContext { get; set; }
        public IAccountContext accountContext { get; set; }
        public IModelContext db { get; set; }
        public GetDefaultOrganizationQuerydHandler(IModelContext db, IUserContext userContext, IAccountContext accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

        public  IList<IResult> Handle(GetDefaultOrganizationtQuery getDefaultOrganizationtQuery)
        {
            var handler = db.Organizations.Where(m => !m.Inactive && m.IsParent).FirstOrDefault();

            if(handler == null)
               throw  new DataProcessingException("Default organisation is not set. Please contact your administrator.");

            var result = new List<IResult>();

            result.Add(new DefaultOrgnizationResult
            {
                Id = handler.Id,
                Name = handler.Name,
                Inactive = handler.Inactive,
                CreatedDate = handler.CreatedDate,
                IsParent = handler.IsParent
            });

            return result;
        }
    }
}
