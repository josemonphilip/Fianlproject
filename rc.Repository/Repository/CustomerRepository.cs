using rc.DAL;
using rc.Domain;
using rc.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Repository
{
    public class CustomerRepository :BaseRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(IDatabaseFactory dbf)
            : base(dbf)
        {}
    }
}
