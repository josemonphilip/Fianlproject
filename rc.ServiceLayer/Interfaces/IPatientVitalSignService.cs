using rc.Domain;
using rc.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer.Interfaces
{
    public interface IPatientVitalSignService
    {
        VitalSignViewModel VitalSignDetails(int PatientID, int CustID);
        void Save(PatientVitalSign pv);
        List<PatientVitalSign> ListVitalSign(int PatientID, int CustID);
    }
}
