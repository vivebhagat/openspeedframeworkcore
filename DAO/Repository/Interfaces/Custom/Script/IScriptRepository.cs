using SpeedFramework.DAO.Model.Custom.Scripting;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IScriptRepository: IGenericActivableRepository<Script>
    {
        dynamic RunScript(dynamic payload, int Id);
    }
}
