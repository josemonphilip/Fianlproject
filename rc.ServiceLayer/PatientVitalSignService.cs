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
    public class PatientVitalSignService : IPatientVitalSignService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientVitalSignRepository _vitalSign;
        private readonly IPatientAdmissionRepository _patientAdmisson;
        public PatientVitalSignService(IUnitOfWork unitOfWork,IPatientVitalSignRepository vitalSign,IPatientAdmissionRepository patientAdmisson)
        {
            _unitOfWork = unitOfWork;
            _vitalSign = vitalSign;
            _patientAdmisson=patientAdmisson;
        }

        public VitalSignViewModel VitalSignDetails(int PatientID,int CustID)
        {
            return new VitalSignViewModel
            {
                PatientAdmission=_patientAdmisson.SearchFor(p=>p.PatientAdmissionID==PatientID && p.CustomerID==CustID).SingleOrDefault()
                ,PatientVitalSigns=_vitalSign.SearchFor(v=>v.PatientID==PatientID).OrderByDescending(v=>v.EntryDate).ToList()
            };
        }

        public List<PatientVitalSign> ListVitalSign(int PatientID,int CustID)
        {
            return _vitalSign.SearchFor(v => v.PatientID == PatientID && v.CompanyID==CustID).OrderBy(a=>a.EntryDate).ToList();
        }

        public void Save(PatientVitalSign pv)
        {
            _vitalSign.Add(pv);
            _unitOfWork.Save();
        }
    }
}
 