using ProjectManagement.Models;

namespace ProjectManagement.Data.Repositories
{
    public class ConsultantRepository : GenericRepository<Consultant>, IConsultantRepository
    {
        public ConsultantRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
