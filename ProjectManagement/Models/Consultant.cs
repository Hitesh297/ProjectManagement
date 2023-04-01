using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjectManagement.Models
{
    public class Consultant
    {
        public int Id { get; set; }
        [Display(Name = "Consultant Id")]
        public string UniqueConsultantId { get; set; }
        [Display(Name = "Consultant Name")]
        public string Name { get; set; }
        [Display(Name = "Recruiter")]
        [ForeignKey("Recruiter")]
        public int? RecruiterMemberId { get; set; }
        [Display(Name = "Team Lead")]
        [ForeignKey("TeamLead")]
        public int? TeamLeadMemberId { get; set; }
        [Display(Name = "Marketing Manager")]
        [ForeignKey("MarketingManager")]
        public int? MarketingManagerMemberId { get; set; }
        [Display(Name = "Team Member")]
        [ForeignKey("TeamMember")]
        public int? TeamMemberId { get; set; }
        [Display(Name = "Referred By")]
        [ForeignKey("ReferredBy")]
        public int? ReferredByMemberId { get; set; }
        [Display(Name = "Placed By")]
        [ForeignKey("PlacedBy")]
        public int? PlacedByMemberId { get; set; }
        public virtual TeamMember? Recruiter { get; set; }
        public virtual TeamMember? TeamLead { get; set; }

        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string Status
        {
            get
            {
                if (EndDate == null)
                {
                    return "Active";
                }
                return "Inactive";
            }

        }


        [Display(Name = "Client")]
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public virtual Client? Client { get; set; }
        public TeamMember? TeamMember { get; set; }
        [Display(Name = "Billing Rate")]
        public decimal BillingRate { get; set; }
        [Display(Name = "Pay Rate")]
        public decimal PayRate { get; set; }
        [Display(Name = "Team Lead Fee")]
        public decimal TeamLeadFee { get; set; }
        [Display(Name = "Marketing Fee")]
        public decimal MarketingFee { get; set;}
        public TeamMember? MarketingManager { get; set; }
        [Display(Name = "Referral Fee")]
        public decimal ReferralFees { get; set; }
        public TeamMember? ReferredBy { get; set; }
        [Display(Name = "Placement Fee")]
        public decimal PlacementFee { get; set; }
        public TeamMember? PlacedBy { get; set; }
        [Display(Name = "Credit Card Cost")]
        public decimal CreditCardCost { get; set; }
        [Display(Name = "Net Margin")]
        public decimal NetMargin { get; set; }
    }
}
