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
    public class PatientDailyDiaryService : IPatientDailyDiaryService
    {
        private IPatientDailyDiaryRepository _patientDailyDiaryRepository;
        private readonly IUnitOfWork _uow;
        private readonly IPatientAdmissionRepository _patientAdmissionRepository;
        private readonly ICarePlanRepository _CarePlan;
        public PatientDailyDiaryService(IPatientDailyDiaryRepository patientDailyDiaryRepository, IUnitOfWork uow,
                    IPatientAdmissionRepository patientAdmissionRepository, ICarePlanRepository CarePlan)
        {
            _patientDailyDiaryRepository = patientDailyDiaryRepository;
            _uow = uow;
            _patientAdmissionRepository = patientAdmissionRepository;
            _CarePlan = CarePlan;
        }

        public PatientDiaryViewModel DiaryDetails(int PatientID,int CustID)
        {
           return new PatientDiaryViewModel
            {
                PatientAdmission = _patientAdmissionRepository.SearchFor(p => p.CustomerID == CustID && p.PatientAdmissionID == PatientID).SingleOrDefault(),
                PatientDailyDiary = new PatientDailyDiary(),
                PatientDailyDiaryList = _patientDailyDiaryRepository.SearchFor(d => d.CustomerID == CustID && d.PatientID == PatientID).OrderByDescending(r => r.EntryDate).ToList(),
                CarePlans = _CarePlan.SearchFor(c => c.PatientID == PatientID && c.CustomerID==CustID).ToList()
            };
          
        }

        public void Save(PatientDailyDiary PatientDailyDiary)
        {
            _patientDailyDiaryRepository.Add(PatientDailyDiary);
            _uow.Save();
        }

        public List<PatientDailyDiary> ListDailyNote(int PatientID)
        {
            return _patientDailyDiaryRepository.SearchFor(d => d.PatientID == PatientID).OrderByDescending(c=>c.EntryDate).ToList();
        }
    }
}
