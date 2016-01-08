using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class PatientDailyDiary
    {
        public int PatientDailyDiaryID { get; set; }
        public DateTime EntryDate { get; set; }
        public int PatientID { get; set; }

        [Required]
        public string DiaryNotes { get; set; }
        public int Priority { get; set; }
        public int CustomerID { get; set; }

        [ForeignKey("PatientID")]
        public virtual PatientAdmission PatientAdmission { get; set; }

    }
}
