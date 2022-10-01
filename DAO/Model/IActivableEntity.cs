namespace SpeedFramework.Common.CoreModels
{
    public interface IActivableEntity : TEntity
    {
        bool Inactive { get; set; }
    }
}