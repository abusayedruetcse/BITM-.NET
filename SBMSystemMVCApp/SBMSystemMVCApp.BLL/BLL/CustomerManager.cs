using SBMSystemMVCApp.Models.Models;
using SBMSystemMVCApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystemMVCApp.BLL.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository;
        public CustomerManager()
        {
            _customerRepository = new CustomerRepository();
        }
        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }
        public bool IsCodeDuplicate(Customer customer)
        {
            return _customerRepository.IsCodeDuplicate(customer);
        }
        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }
        public bool isUpdated(Customer customer)
        {
            return _customerRepository.isUpdated(customer);
        }
    }
}
