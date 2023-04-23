using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectManagement.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public bool Equals(Client x, Client y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Client obj)
        {
            return obj.Id.GetHashCode() ^
                obj.ClientName.GetHashCode();
        }

    }
}
