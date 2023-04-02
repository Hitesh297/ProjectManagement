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
        [Display(Name = "January")]
        public decimal? JanBilling { get; set; }
        [Display(Name = "February")]
        public decimal? FebBilling { get; set; }
        [Display(Name = "March")]
        public decimal? MarBilling { get; set; }
        [Display(Name = "April")]
        public decimal? AprBilling { get; set; }
        [Display(Name = "May")]
        public decimal? MayBilling { get; set; }
        [Display(Name = "June")]
        public decimal? JunBilling { get; set; }
        [Display(Name = "July")]
        public decimal? JulBilling { get; set; }
        [Display(Name = "August")]
        public decimal? AugBilling { get; set; }
        [Display(Name = "September")]
        public decimal? SepBilling { get; set; }
        [Display(Name = "October")]
        public decimal? OctBilling { get; set; }
        [Display(Name = "November")]
        public decimal? NovBilling { get; set; }
        [Display(Name = "December")]
        public decimal? DecBilling { get; set; }

    }
}
