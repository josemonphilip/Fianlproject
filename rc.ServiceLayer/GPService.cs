using rc.Domain;
using rc.Repository.Interface;
using rc.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer
{
    public class GPService : IGPService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IGPRepository _gpRepository;
        public GPService(IGPRepository gpRepository, IUnitOfWork unitOfWork)
        {
            this._gpRepository = gpRepository;
            _unitOfWork = unitOfWork;
        }



        public IEnumerable<GeneralPractitioner> GetAllGps()
        {
            return _gpRepository.All;
        }
        public IEnumerable<GeneralPractitioner> GetAllGpsForCompany(int id)
        {
            return _gpRepository.SearchFor(g => g.CustomerID == id).ToList();
        }
        public IEnumerable<GeneralPractitioner> GetAllGpsByCustomerID(int custId)
        {
            return _gpRepository.SearchFor(g=>g.CustomerID==custId);
        }

        public GeneralPractitioner GetGpByID(int GPID,int CompId)
        {
            return _gpRepository.SearchFor(g=>g.GeneralPractitionerID==GPID && g.CustomerID==CompId).SingleOrDefault();
        }


        public GeneralPractitioner GetGp(int GPID)
        {
            return _gpRepository.Find(GPID);
        }

        public void CreateGp(GeneralPractitioner Gp)
        {
            _gpRepository.Add(Gp);
            _unitOfWork.Save();
        }

        public void EditGp(GeneralPractitioner Gp)
        {
            _gpRepository.Update(Gp);
            _unitOfWork.Save();
        }

        public List<BrokenBusinessRules> Validate(GeneralPractitioner Gp)
        {
            List<BrokenBusinessRules> brokenRules = new List<BrokenBusinessRules>();
            if (Gp.FirstName ==null)
            {
                brokenRules.Add(new BrokenBusinessRules("FirstName", "First name is must.."));
            }
            return brokenRules;

        }
    }
}
