using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class CarePlan
    {
        public int CarePlanID { get; set; }
        public int PatientID { get; set; }
        [Required]
        public string CarePlanDesc { get; set; }
        [Required]
        public string Goal { get; set; }
        [Required]
        public string Intervention { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("PatientID")]
        public virtual PatientAdmission PatientAdmission { get; set; }
    }
}
