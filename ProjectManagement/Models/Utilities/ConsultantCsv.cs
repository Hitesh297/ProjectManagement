using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace ProjectManagement.Models.Utilities
{
    public class ConsultantCsv
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string UniqueConsultantId { get; set; }
        public int RecruiterMemberId { get; set; }
        public int TeamMemberId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal BillingRate { get; set; }
        public decimal PayRate { get; set; }
        public decimal TeamLeadFee { get; set; }
        public int TeamLeadMemberId { get; set; }
        public decimal MarketingFee { get; set; }
        public int MarketingManagerMemberId { get; set; }
        public decimal ReferralFees { get; set; }
        public int ReferredByMemberId { get; set; }
        public decimal PlacementFee { get; set; }
        public int PlacedByMemberId { get; set; }
        public decimal CreditCardCost { get; set; }

        public decimal NetMargin
        {
            get
            {
                // any change in formula here, will require change in Consultant.js too
                decimal creditCardPerecentToValue = (CreditCardCost / 100) * BillingRate;
                decimal netMargin = BillingRate - (TeamLeadFee + MarketingFee + ReferralFees + PlacementFee + creditCardPerecentToValue);
                return netMargin;
            }

        }

    }
}
