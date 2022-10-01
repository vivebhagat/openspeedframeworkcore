using System.Collections.Generic;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IGlobalRepository
    {
        IEnumerable<dynamic> Search(string q);
    }

}
