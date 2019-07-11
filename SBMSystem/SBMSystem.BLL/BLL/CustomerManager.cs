using SBMSystem.Models.Models;
using SBMSystem.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystem.BLL.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository;
        public CustomerManager()
        {
            _customerRepository = new CustomerRepository();
        }
        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }
    }
}
