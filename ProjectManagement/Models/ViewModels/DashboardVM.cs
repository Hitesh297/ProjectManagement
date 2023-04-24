namespace ProjectManagement.Models.ViewModels
{
    public class DashboardVM
    {
        public ConsultantByClientVM ConsultantByClientVM { get; set; }
        public RevenueByRecruiterVM RevenueByRecruiterVM { get; set; }

        public RevenueByClientVM RevenueByClientVM { get; set; }
    }

    public class RevenueByClientVM
    {
        public List<ClientProfitByMonth>? ClientByProfitList { get; set; }
    }

    public class ClientProfitByMonth
    {
        public int Month { get; set; }
        public Client Client { get; set; }
        public decimal? NetProfitByClient { get; set; }
    }

    public class RevenueByRecruiterVM
    {
        public List<RecruiterProfitByMonth>? RecruiterByProfitList { get; set; }
    }

    public class ConsultantByClientVM
    {
        public List<ClientConsultantsByMonth>? ClientByMonthList { get; set; }

    }

    public class RecruiterProfitByMonth
    {
        public int Month { get; set; }
        public TeamMember Recruiter { get; set; }
        public decimal? NetProfitByRecruiter { get; set; }
    }

    public class ClientConsultantsByMonth
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public Client Client { get; set; }
        public int ActiveConsultants { get; set; }
    }
}
