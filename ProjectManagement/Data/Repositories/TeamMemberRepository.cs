using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

namespace ProjectManagement.Data.Repositories
{
    public class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<TeamMember>> GetAllActiveAsync()
        {
            return await _context.TeamMembers.Where(x => x.IsActive).ToListAsync();
        }

        public IEnumerable<TeamMember> GetAllActive()
        {
            return _context.TeamMembers.Where(x => x.IsActive).ToList();
        }
    }
}
