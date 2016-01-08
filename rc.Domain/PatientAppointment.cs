using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class PatientAppointment
    {
        public int PatientAppointmentID { get; set; }
        [DisplayName("Date")]
        public DateTime AppointmentDate { get; set; }
        public string Desctiprion { get; set; }
        public int PatientID { get; set; }
        public int CustID { get; set; }
        public int Status { get; set; }

        [ForeignKey("PatientID")]
        public virtual PatientAdmission PatientAdmission { get; set; }
    }
}
