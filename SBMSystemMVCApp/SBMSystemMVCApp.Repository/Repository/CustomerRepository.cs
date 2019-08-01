using SBMSystemMVCApp.DatabaseContext.DatabaseContext;
using SBMSystemMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystemMVCApp.Repository.Repository
{
    public class CustomerRepository
    {
        SBMSystemDbContext db;
        public CustomerRepository()
        {
            db = new SBMSystemDbContext();
        }
        public bool Add(Customer customer)
        {
            int isExecuted = 0;
            db.Customers.Add(customer);
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        } 
        public bool IsCodeDuplicate(Customer customer)
        {
            var aCustomer = db.Customers.FirstOrDefault(c => c.Code == customer.Code);
            if(aCustomer!=null)
            {
                return true;
            }
            return false ;
        } 
        public List<Customer> GetAll()
        {
            var customers = db.Customers.ToList();
            return customers;
        }
    }
}
