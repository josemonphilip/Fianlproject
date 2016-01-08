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
    public class PatientService : IPatientService
    {

        private readonly IPatientAdmissionRepository _patientAdmissionRepository;
        private readonly IUnitOfWork _uow;
        private readonly ICarePlanRepository _carePlan;
        private readonly IPatientAppointmentRepository _patientAppointment;
        public PatientService(IPatientAdmissionRepository patientAdmissionRepository, IUnitOfWork uow, ICarePlanRepository carePlan,
                            IPatientAppointmentRepository patientAppointment)
        {

            this._patientAdmissionRepository = patientAdmissionRepository;
            this._uow = uow;
            this._carePlan = carePlan;
            this._patientAppointment = patientAppointment;
        }

        public PatientAdmission GetPatientDetails(int id)
        {
            return _patientAdmissionRepository.Find(id);
        }
        public void CreatePatientAdmission(PatientAdmission patientAdmission)
        {
            _patientAdmissionRepository.Add(patientAdmission);
            _uow.Save();
        }

        public PatientViewModel getPatientDetailsById(int id)
        {
            PatientAdmission patientAdmitionDetails= _patientAdmissionRepository.Find(id);

            DateTime frmdt = DateTime.Today.Date;
            DateTime todate = DateTime.Today.AddDays(1).Date;
            return new PatientViewModel
            {
                patientAdmission = patientAdmitionDetails,
                CarePlans = _carePlan.SearchFor(c=>c.PatientID==id).ToList(),
                PatientAppointments = _patientAppointment.SearchFor(a => a.PatientID == id && a.AppointmentDate >= frmdt && a.AppointmentDate < todate).ToList() //&& a.CustID == CustID
          
            };

        }

        public List<PatientAdmission> GetPatientList(int CustID)
        {
            return _patientAdmissionRepository.SearchFor(p => p.CustomerID == CustID).ToList();
        }

        public List<PatientAdmission> PatientBirthdayList(int id)
        {
             DateTime frmdt = DateTime.Today.Date;
             var day = frmdt.Day;
             var mth = frmdt.Month;
             return (_patientAdmissionRepository.SearchFor(p => p.CustomerID == id && p.DOB.Month == mth).OrderBy(p => p.DOB).ToList());
        }

    }
}
