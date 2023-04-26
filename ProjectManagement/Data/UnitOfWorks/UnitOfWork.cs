using ProjectManagement.Data.Repositories;

namespace ProjectManagement.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, 
            IClientRepository clientRepository, 
            IConsultantRepository consultantRepository, 
            ITeamMemberRepository teamMemberRepository,
            ITimeSheetRepository timeSheetRepository,
            IMonthDataRepository monthDataRepository)
        {
            _context = context;
            Clients = clientRepository;
            Consultants = consultantRepository;
            TeamMembers = teamMemberRepository;
            TimeSheets = timeSheetRepository;
            MonthData = monthDataRepository;
        }
        public IClientRepository Clients { get; private set; }
        public IConsultantRepository Consultants { get; private set; }
        public ITeamMemberRepository TeamMembers { get; private set; }
        public ITimeSheetRepository TimeSheets { get; private set; }
        public IMonthDataRepository MonthData { get; private set; }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
