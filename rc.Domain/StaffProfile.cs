using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class StaffProfile
    {
        public int StaffProfileID { get; set; }
        [Required(ErrorMessage="First Name required")]
        [StringLength(50,ErrorMessage="First Name Should under 50 character")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Last Name required")]
        [StringLength(50, ErrorMessage = "Last Name Should under 50 character")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage="Staff Number required")]
        [StringLength(30)]
        [DisplayName("Staff No")]
        public string StaffNo { get; set; }
        [StringLength(15)]
        [DisplayName("PPS No")]
        public string StaffPPSNo { get; set; }
        [DisplayName("Address")]
        public string StaffAddress { get; set; }
        [Required(ErrorMessage="Must enter a phone no.")]
        [StringLength(50)]
        [DisplayName("Phone No")]
        public string StaffPhone { get; set; }
        [EmailAddress]
        [StringLength(30,ErrorMessage="Max length is 30")]
        [DisplayName("Email")]
        public string StaffEmail { get; set; }

        public Guid CompCode { get; set; }
         [StringLength(128)]
        public string UserId { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

    }
}
