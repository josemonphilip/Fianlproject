using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain.ViewModel
{
    public class PatientDiaryViewModel
    {
        public PatientAdmission PatientAdmission { get; set; }
        public PatientDailyDiary PatientDailyDiary { get; set; }
        public List<PatientDailyDiary> PatientDailyDiaryList { get; set; }
        public List<CarePlan> CarePlans { get; set; }
        //TODO Care plans
    }
}
