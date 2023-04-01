using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        //public ICollection<Consultant> Consultants { get; set; }
        [InverseProperty("Recruiter")]
        public virtual ICollection<Consultant>? RecruiterInConsultants { get; set; }

        [InverseProperty("TeamLead")]
        public virtual ICollection<Consultant>? TeamLeadInConsultants { get; set; }

        [InverseProperty("MarketingManager")]
        public virtual ICollection<Consultant>? MarketingManagerInConsultants { get; set; }
        [InverseProperty("TeamMember")]
        public virtual ICollection<Consultant>? TeamMemberInConsultants { get; set; }
        [InverseProperty("ReferredBy")]
        public virtual ICollection<Consultant>? ReferredByInConsultants { get; set; }
        [InverseProperty("PlacedBy")]
        public virtual ICollection<Consultant>? PlacedByInConsultants { get; set; }
    }
}
