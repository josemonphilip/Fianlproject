using rc.Domain;
using rc.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer.Interfaces
{
    public interface ICarePlanService
    {
        CarePlanViewModel CarePlanDetails(int PatientID, int CustID);
        void SaveCarePlan(CarePlan cPlan);
        CarePlanViewModel CarePlanList(int PatientID, int CustID);
        void UpdateCarePlan(CarePlan cPlan);
        CarePlanViewModel CarePlanEdit(int PatientID, int CustID, int id);
    }
}
