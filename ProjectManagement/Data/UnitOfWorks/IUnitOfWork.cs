using ProjectManagement.Data.Repositories;

namespace ProjectManagement.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        IConsultantRepository Consultants { get; }
        ITeamMemberRepository TeamMembers { get; }
        ITimeSheetRepository TimeSheets { get; }
        IMonthDataRepository MonthData { get; }
        Task<int> Complete();
    }
}
