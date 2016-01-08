using rc.Domain;
using rc.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer.Interfaces
{
    public interface IPatientService
    {
        void CreatePatientAdmission(PatientAdmission patientAdmission);
        PatientViewModel getPatientDetailsById(int id);
        List<PatientAdmission> GetPatientList(int CustID);
        List<PatientAdmission> PatientBirthdayList(int id);
    }
}
