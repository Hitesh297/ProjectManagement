using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

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

       
        public decimal? ConsultantPay { get; set; }
        public decimal? Variation
        {
            get
            {
                if (this.ConsultantPay != null && this.PaidAmount != null)
                {
                    return ConsultantPay - PaidAmount;
                }
                return 0;
            }
        }
      
    }
    public sealed class TimesheetCsvMap : ClassMap<TimesheetCsv>
    {
        public TimesheetCsvMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.ConsultantPay).Ignore();
        }
    }
}
