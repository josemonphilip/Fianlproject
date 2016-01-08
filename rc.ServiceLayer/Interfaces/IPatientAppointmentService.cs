using rc.Domain;
using rc.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer.Interfaces
{
    public interface IPatientAppointmentService
    {
        PatientAppointmentViewModel GetAppointmentDetails(int PatientID, int CustID);
        void Create(PatientAppointment model);
        List<PatientAppointment> ListAppoinment(int PatientID, int CustID);
        PatientAppointmentViewModel GetAppointmentList(int PatientID, int CustID);
        PatientAppointmentViewModel GetAppointmentForEdit(int PatientID, int CustID, int id);
        EmployeeDashboardViewModel ListTodaysAppoinment(int CustID);
        
        
    }
}
