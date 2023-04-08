using ProjectManagement.Models;

namespace ProjectManagement.Data.Repositories
{
    public interface ITeamMemberRepository : IGenericRepository<TeamMember>
    {
        Task<IEnumerable<TeamMember>> GetAllActiveAsync();
        IEnumerable<TeamMember> GetAllActive();
    }
}
