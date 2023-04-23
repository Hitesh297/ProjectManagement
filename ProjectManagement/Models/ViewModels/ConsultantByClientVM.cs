namespace ProjectManagement.Models.ViewModels
{
    public class ConsultantByClientVM
    {
        public List<ClientByMonth>? ClientByMonthList { get; set; }

    }

    public class ClientByMonth
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public Client Client { get; set; }
        public int ActiveConsultants { get; set; }
    }


}
