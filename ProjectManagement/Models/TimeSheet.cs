﻿using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Invoice Amount")]
        public decimal? InvoiceAmount { get; set; }
        [Display(Name = "Consultant Pay")]
        public decimal? ConsultantPay { get; set; }
        [Display(Name = "Paid Amount")]
        public decimal? PaidAmount { get; set; }
        [Display(Name = "Variation")]
        public decimal? Variation { get; set; }
        [Display(Name = "Net Profit")]
        public decimal? NetProfit { get; set; }
        [ForeignKey("Timesheet")]
        public int TimesheetId { get; set; }
        public virtual TimeSheet? TimeSheet { get; set; }

    }
}
