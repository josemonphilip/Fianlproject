using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class GeneralPractitioner
    {
        public int GeneralPractitionerID { get; set; }
        [Required]
        [StringLength(50)]
        public string SurName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        public string Address { get; set; }
        [StringLength(30)]
        [Required]
        public string Phone { get; set; }
        [StringLength(30)]
        public string Mobile { get; set; }
        [StringLength(30)]
        public string Fax { get; set; }
        public string AdditionalNote { get; set; }

        public int CustomerID { get; set; }

       // [ForeignKey("CustomerID")]
       // public Customer Customer { get; set; }
    }
}
