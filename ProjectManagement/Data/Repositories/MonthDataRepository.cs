using ProjectManagement.Models;

namespace ProjectManagement.Data.Repositories
{
    public class MonthDataRepository : GenericRepository<MonthData>, IMonthDataRepository
    {
        public MonthDataRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
