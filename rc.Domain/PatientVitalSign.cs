using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class PatientVitalSign
    {
        public int PatientVitalSignID { get; set; }
        public int PatientID { get; set; }
        public DateTime EntryDate { get; set; }
        
        public int BP1 { get; set; }
        public int BP2 { get; set; }
        public int Pulse { get; set; }
        public int Respiration { get; set; }
        public int Tempeature { get; set; }
        public int Weight { get; set; }
        public string Notes { get; set; }

        public int CompanyID { get; set; }
        [ForeignKey("PatientID")]
        public virtual PatientAdmission PatientAdmission { get; set; }
    }
}
