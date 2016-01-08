using rc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer.Interfaces
{
    public interface IGPService
    {
        IEnumerable<GeneralPractitioner> GetAllGps();
        GeneralPractitioner GetGp(int GPID);
        void CreateGp(GeneralPractitioner Gp);
        void EditGp(GeneralPractitioner Gp);
        IEnumerable<GeneralPractitioner> GetAllGpsByCustomerID(int custId);
        IEnumerable<GeneralPractitioner> GetAllGpsForCompany(int id);
        GeneralPractitioner GetGpByID(int GPID, int CompId);
    }
}
