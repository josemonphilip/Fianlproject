using rc.Domain;
using rc.Domain.ViewModel;
using rc.Repository.Interface;
using rc.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer
{
    public class PatientAppointmentService : IPatientAppointmentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IPatientAppointmentRepository _patientAppointment;
        private readonly IPatientAdmissionRepository _patientAdmission;
        private readonly IPatientService _PService;
        public PatientAppointmentService(IUnitOfWork uow, IPatientAppointmentRepository patientAppointment,
                                         IPatientAdmissionRepository patientAdmission, IPatientService PService)
        {
            _uow = uow;
            _patientAppointment = patientAppointment;
            _patientAdmission = patientAdmission;
            _PService = PService;
        }

        public PatientAppointmentViewModel GetAppointmentDetails(int PatientID, int CustID)
        {
            return new PatientAppointmentViewModel
            {
                //PatientAppointment=new PatientAppointment(),
                PatientAdmission = _patientAdmission.SearchFor(p=>p.PatientAdmissionID==PatientID & p.CustomerID==CustID).SingleOrDefault()
            };
        }

        public PatientAppointmentViewModel GetAppointmentList(int PatientID, int CustID)
        {
            return new PatientAppointmentViewModel
            {
                //PatientAppointment=new PatientAppointment(),
                PatientAdmission = _patientAdmission.SearchFor(p => p.PatientAdmissionID == PatientID & p.CustomerID == CustID).SingleOrDefault(),
                PatientAppointments = _patientAppointment.SearchFor(a => a.PatientID == PatientID && a.CustID == CustID).OrderByDescending(a=>a.AppointmentDate).ToList()
            };
        }

        public PatientAppointmentViewModel GetAppointmentForEdit(int PatientID, int CustID,int id)
        {
            return new PatientAppointmentViewModel
            {
                PatientAppointment = _patientAppointment.SearchFor(a => a.PatientID == PatientID && a.CustID == CustID && a.PatientAppointmentID==id).SingleOrDefault(),
                PatientAdmission = _patientAdmission.SearchFor(p => p.PatientAdmissionID == PatientID & p.CustomerID == CustID).SingleOrDefault()
            };
        }

        public List<PatientAppointment> ListAppoinment(int PatientID, int CustID)
        {
            return _patientAppointment.SearchFor(a => a.PatientID == PatientID && a.CustID == CustID).ToList();
        }

        public void Create(PatientAppointment model)
        {
            _patientAppointment.Add(model);
            _uow.Save();
        }

        public EmployeeDashboardViewModel ListTodaysAppoinment(int CustID)
        {
            DateTime frmdt = DateTime.Today.Date;
            DateTime todate = DateTime.Today.AddDays(1).Date;
            return new EmployeeDashboardViewModel
            {
                PatientAppointments = _patientAppointment.SearchFor(a => a.CustID == CustID && a.AppointmentDate >= frmdt && a.AppointmentDate < todate).ToList(),
                Birthdays = _PService.PatientBirthdayList(CustID)
            };
        }


    }
}
