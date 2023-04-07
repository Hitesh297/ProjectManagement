using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjectManagement.Models
{
    public class TimeSheet
    {
        public int Id { get; set; }
        [Display(Name = "Consultant")]
        [ForeignKey("Consultant")]
        public int? ConsultantId { get; set; }
        public virtual Consultant? Consultant { get; set; }
        public int Year { get; set; }
        public virtual ICollection<MonthData>? MonthData { get; set; }

    }

    public class MonthData
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int MonthInt { get; set; }
        public decimal? Hours { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? ConsultantPay { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? Variation { get; set; }
        [ForeignKey("Timesheet")]
        public int TimesheetId { get; set; }
        public virtual TimeSheet? TimeSheet { get; set; }

    }
}
