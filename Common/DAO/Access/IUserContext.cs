using System;
using System.Collections.Generic;

namespace Common.DAO.Access
{

    public interface IUserContext
    {
        int CurrentUserId { get; set; }
        int CurrentRoleId { get; set; }
        List<Tuple<string, string>> preferences { get; set; }
    }


}
