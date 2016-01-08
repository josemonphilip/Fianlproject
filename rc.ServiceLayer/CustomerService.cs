using rc.Domain;
using rc.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository,IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._customerRepository = customerRepository;
        }


        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.All;
        }
        public Customer GetCustomer(int CustomerID)
        {
            return _customerRepository.Find(CustomerID);
        }
        public void CreateCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
            _unitOfWork.Save();
        }
        public void EditCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
            _unitOfWork.Save();
        }
        public Customer getCompanyByGuid(Guid id)
        {
            return _customerRepository.SearchFor(c => c.CompCode == id).SingleOrDefault();
        }
    }
}
