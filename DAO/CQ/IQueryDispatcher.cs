using System.Collections.Generic;

namespace DAO.CQ
{
    public interface IQueryDispatcher
    {
        IList<IResult> Send<T>(T query) where T : IQuery;
    }
}
