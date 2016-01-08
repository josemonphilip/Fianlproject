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
    public class CarePlanService : ICarePlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarePlanRepository _carePlanRepository;
        private readonly IPatientAdmissionRepository _patientAdmissionRepository;
        public CarePlanService(IUnitOfWork unitOfWork, ICarePlanRepository carePlanRepository,
                         IPatientAdmissionRepository patientAdmissionRepository)
        {
            _unitOfWork = unitOfWork;
            _carePlanRepository = carePlanRepository;
            _patientAdmissionRepository = patientAdmissionRepository;
        }

        public CarePlanViewModel CarePlanDetails(int PatientID,int CustID)
        {
            return new CarePlanViewModel
            {
                PatientAdmission = _patientAdmissionRepository.SearchFor(p => p.CustomerID == CustID && p.PatientAdmissionID == PatientID).SingleOrDefault(),
                CarePlan = new CarePlan(),
                CarePlanList = _carePlanRepository.SearchFor(c => c.CustomerID == CustID && c.PatientID == PatientID).ToList()
            };
        }

        public CarePlanViewModel CarePlanList(int PatientID,int CustID)
        {
            return new CarePlanViewModel
            {
                PatientAdmission = _patientAdmissionRepository.SearchFor(p => p.CustomerID == CustID && p.PatientAdmissionID == PatientID).SingleOrDefault(),
                CarePlanList = _carePlanRepository.SearchFor(c => c.PatientID == PatientID).ToList()
            };
        }

        public CarePlanViewModel CarePlanEdit(int PatientID, int CustID,int id)
        {
            return new CarePlanViewModel
            {
                PatientAdmission = _patientAdmissionRepository.SearchFor(p => p.CustomerID == CustID && p.PatientAdmissionID == PatientID).SingleOrDefault(),
                CarePlanList = _carePlanRepository.SearchFor(c => c.PatientID == PatientID).ToList(),
                CarePlan = _carePlanRepository.SearchFor(c => c.PatientID == PatientID && c.CarePlanID==id).SingleOrDefault()
            };
        }
        public void SaveCarePlan(CarePlan cPlan)
        {
            _carePlanRepository.Add(cPlan);
            _unitOfWork.Save();
        }
        public void UpdateCarePlan(CarePlan cPlan)
        {
            _carePlanRepository.Update(cPlan);
            _unitOfWork.Save();
        }
    }
}
