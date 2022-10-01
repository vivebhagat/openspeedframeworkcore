using SpeedFramework.DAO.Model.Access;
using System;
using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IUserDefinedRoleRepository : IGenericActivableRepository<UserDefinedRole>
    {
        IEnumerable<UserDefinedRoleToUserMap> GetFullRoleMap(int Id);
        IEnumerable<UserDefinedRole> GetRoleMap();
        bool MapUserToRole(int userid, int roleid);
        bool UnmapUserFromRole(int userid, int roleid);
   //     List<Tuple<string, object>> GetOwnershipEntityAccessMap();
    }
}