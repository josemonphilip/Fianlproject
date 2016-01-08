using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class Ward
    {
        public int WardID { get; set; }
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "No of Beds Required")]
        public int TotalBeds { get; set; }

        public int CustomerID { get; set; }

       // [ForeignKey("CustomerID")]
       // public virtual Customer Customer { get; set; }

        public virtual ICollection<PatientAdmission> PatientAdmissions { get; set; }
    }
}
