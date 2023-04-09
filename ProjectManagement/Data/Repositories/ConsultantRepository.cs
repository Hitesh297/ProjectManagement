using ProjectManagement.Models;

namespace ProjectManagement.Data.Repositories
{
    public class ConsultantRepository : GenericRepository<Consultant>, IConsultantRepository
    {
        public ConsultantRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        public IEnumerable<Consultant> GetAllActive()
        {
            return _context.Consultants.Where(x => x.EndDate == null).ToList();
        }
    }
}
