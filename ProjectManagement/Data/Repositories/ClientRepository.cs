using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

namespace ProjectManagement.Data.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Client>> GetAllActiveAsync()
        {
            return await _context.Clients.Where(x=>x.IsActive).ToListAsync();
        }

        public IEnumerable<Client> GetAllActive()
        {
            return _context.Clients.Where(x => x.IsActive).ToList();
        }
    }
}
