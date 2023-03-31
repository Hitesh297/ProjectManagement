using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Models
{
    public class Consultant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Recruiter"), Column(Order = 0)]
        public int? RecruiterMemberId { get; set; }
        [ForeignKey("TeamLead"), Column(Order = 1)]
        public int? TeamLeadMemberId { get; set; }
        [ForeignKey("MarketingManager")]
        public int? MarketingManagerMemberId { get; set; }
        [ForeignKey("TeamMember")]
        public int? TeamMemberId { get; set; }
        [ForeignKey("ReferredBy")]
        public int? ReferredByMemberId { get; set; }
        [ForeignKey("PlacedBy")]
        public int? PlacedByMemberId { get; set; }
        public virtual TeamMember? Recruiter { get; set; }
        public virtual TeamMember? TeamLead { get; set; }

        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
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


        //client
        public TeamMember? TeamMember { get; set; }
        public decimal BillingRate { get; set; }
        public decimal PayRate { get; set; }
        public decimal TeamLeadFee { get; set; }
        public decimal MarketingFee { get; set;}
        public TeamMember? MarketingManager { get; set; }
        public decimal ReferralFees { get; set; }
        public TeamMember? ReferredBy { get; set; }
        public decimal PlacementFee { get; set; }
        public TeamMember? PlacedBy { get; set; }
        public decimal CreditCardCost { get; set; }
        public decimal NetMargin { get; set; }
    }
}
