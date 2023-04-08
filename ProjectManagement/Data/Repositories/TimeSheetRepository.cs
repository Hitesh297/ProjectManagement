using ProjectManagement.Models;

namespace ProjectManagement.Data.Repositories
{
    public class TimeSheetRepository : GenericRepository<TimeSheet>, ITimeSheetRepository
    {
        public TimeSheetRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
