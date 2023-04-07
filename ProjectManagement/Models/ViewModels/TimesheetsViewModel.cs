namespace ProjectManagement.Models.ViewModels
{
    public class TimesheetsViewModel
    {
        public int Id { get; set; }
        public int? ConsultantId { get; set; }
        public Consultant? Consultant { get; set; }
        public int Year { get; set; }

        public List<MonthData> MonthData { get; set; }
    }
}
