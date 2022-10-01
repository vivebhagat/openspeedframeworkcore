using Common.DAO.Access;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class GlobalRepository : IGlobalRepository
    {
        IModelContext db;
        IUserContext userContext;
        public GlobalRepository(IModelContext modelContext, IUserContext userContext)
        {
            this.db = modelContext;
            this.userContext = userContext;
        }


        public IEnumerable<dynamic> Search(string q)
        {
            List<object> result = new List<object>();
            IEnumerable<ApplicationEntity> entities = db.ApplicationEntities.Where(m => m.IsGlobalSearchble).ToList();

            foreach (ApplicationEntity ae in entities)
            {
                FilterEngine fe = new FilterEngine();
                List<dynamic> _result = fe.GetGlobalFilteredWrapper(ae.Name, q, db, userContext, 10, 1).ToList();
                string[] aeName = ae.Name.Split(',');
                string Name = aeName[0].Substring(aeName[0].LastIndexOf(".") + 1, aeName[0].Length - aeName[0].LastIndexOf(".") - 1);
                _result.ForEach(m => m.Add("type", Name));
                result.AddRange(_result);
            }
            return result;
        }

    }

}
