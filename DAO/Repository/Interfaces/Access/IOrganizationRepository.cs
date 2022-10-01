using SpeedFramework.DAO.Model.Access;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IOrganizationRepository : IGenericActivableRepository<Organization>
    {
        Organization GetDefault();
    }
}
