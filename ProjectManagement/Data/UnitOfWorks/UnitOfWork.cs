using ProjectManagement.Data.Repositories;

namespace ProjectManagement.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Clients = new ClientRepository(_context);
            Consultants = new ConsultantRepository(_context);
            TeamMembers = new TeamMemberRepository(_context);
            TimeSheets = new TimeSheetRepository(_context);
        }
        public IClientRepository Clients { get; private set; }
        public IConsultantRepository Consultants { get; private set; }
        public ITeamMemberRepository TeamMembers { get; private set; }
        public ITimeSheetRepository TimeSheets { get; private set; }
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
