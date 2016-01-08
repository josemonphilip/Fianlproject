using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }
        [Required]
        [StringLength(50)]
        public string NursingHomeName { get; set; }
        [StringLength(20)]
        public string RegistrationNo { get; set; }
        public string Address { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(30)]
        public string County { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(30)]
        public string Phone { get; set; }
        [StringLength(30)]
        public string Fax { get; set; }
        [StringLength(30)]
        public string Website { get; set; }
        public string AditionalInfo { get; set; }
        public Guid CompCode { get; set; }
        public virtual ICollection<StaffProfile> StaffProfiles { get; set; }
        public virtual ICollection<PatientAdmission> PatientAdmissions { get; set; }
        //public virtual ICollection<GeneralPractitioner> GeneralPractitioners { get; set; }

       // public virtual ICollection<Ward> Wards { get; set; }
    }
}
