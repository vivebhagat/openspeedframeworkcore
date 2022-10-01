using SpeedFramework.APILib.Models.Authentication;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WebApi.Services
{
    public interface IStageService
    {
        Dictionary<int, string> GetRolesForUser(string dataroute, string username);
        int AddUser(string dataroute, IDictionary<string, string> properties);
    }


    internal class StageService : IStageService 
    {

        IModelContext modelContext;
        public StageService(IModelContext modelContext)
        {
            this.modelContext = modelContext;
        }

        public  Dictionary<int, string> GetRolesForUser(string dataroute, string username)
        {
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            var roles = modelContext.UserDefinedRoleToUserMaps.Where(m => m.IntUser.Name == username).ToList();

            foreach (UserDefinedRoleToUserMap rolemap in roles)
            {
                var roleName = modelContext.UserDefinedRoles.Where(m => m.Id == rolemap.RoleId).FirstOrDefault().Name;
                keyValuePairs.Add(rolemap.RoleId.Value, roleName);
            }

            return keyValuePairs;
        }

        public int AddUser(string dataroute, IDictionary<string,string> properties)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            Organization organization = modelContext.Organizations.Where(m => m.IsParent).FirstOrDefault();
            IntUser user = new IntUser
            {
                FirstName = properties["FirstName"],
                Email = properties["Email"],
                DOB = System.DateTime.ParseExact(properties["DOB"], "dd/MM/yyyy", provider),
                Name = properties["Name"],  
                Org = organization,
                OrgId = organization.Id
            };
            
            modelContext.IntUsers.Add(user);
            modelContext.SaveChanges();

            return user.Id;
        }
    }
}