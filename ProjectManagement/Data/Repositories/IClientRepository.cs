using ProjectManagement.Models;

namespace ProjectManagement.Data.Repositories
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllActiveAsync();
        IEnumerable<Client> GetAllActive();
    }
}
