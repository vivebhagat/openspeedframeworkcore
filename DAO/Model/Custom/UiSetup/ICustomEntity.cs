using SpeedFramework.Common.CoreModels;

namespace SpeedFramework.DAO.Core.Model.UiSetup
{
    public interface IApplicationEntity : IActivableEntity
    {
        string Name { get; set; }
    }
}