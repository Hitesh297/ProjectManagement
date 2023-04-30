namespace ProjectManagement.Models.Utilities
{
    public class TimesheetCsv
    {
        public string UniqueConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public decimal? Hours { get; set; }
        public decimal? PaidAmount { get; set; }
        public int MonthNumber { get; set; }
        public int Year { get; set; }
    }
}
