using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain.ViewModel
{
    public class CarePlanViewModel
    {
        public PatientAdmission PatientAdmission { get; set; }
        public CarePlan CarePlan { get; set; }
        public List<CarePlan> CarePlanList { get; set; }
    }
}
