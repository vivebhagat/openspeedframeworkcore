using System;
using System.Collections.Generic;

namespace DAO.CQ
{
    public interface IQueryHandler<T> : IQueryHandler where T : IQuery
    {
        IList<IResult> Handle(T query);
    }
}
