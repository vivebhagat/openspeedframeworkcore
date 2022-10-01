using System.Threading.Tasks;

namespace DAO.CQ
{
    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        Task Handle(T command);
    }
}
