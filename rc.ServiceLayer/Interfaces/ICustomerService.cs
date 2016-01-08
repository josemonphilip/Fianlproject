using rc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int CustomerID);
        void CreateCustomer(Customer customer);
        void EditCustomer(Customer customer);
        Customer getCompanyByGuid(Guid id);
    }
    
}
