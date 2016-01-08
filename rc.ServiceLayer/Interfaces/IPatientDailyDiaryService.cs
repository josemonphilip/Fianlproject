using rc.Domain;
using rc.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer.Interfaces
{
    public interface IPatientDailyDiaryService
    {
        void Save(PatientDailyDiary PatientDailyDiary);
        PatientDiaryViewModel DiaryDetails(int PatientID, int CustID);
        List<PatientDailyDiary> ListDailyNote(int PatientID);
    }
}
