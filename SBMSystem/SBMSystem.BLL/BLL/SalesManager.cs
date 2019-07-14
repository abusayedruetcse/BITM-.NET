using SBMSystem.Models.Models;
using SBMSystem.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystem.BLL.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository;
        public SalesManager()
        {
            _salesRepository = new SalesRepository();
        }
        public DataTable LoadCustomerToComboBox()
        {
            return _salesRepository.LoadCustomerToComboBox();
        }
        public int GetLoyaltyPoint(Customer customer)
        {
            return _salesRepository.GetLoyaltyPoint(customer);
        }
        public DataTable LoadProductToComboBox()
        {
            return _salesRepository.LoadProductToComboBox();
        }
        public DataTable GetAvailableQuantityAndUnitPrice(Product product)
        {
            return _salesRepository.GetAvailableQuantityAndUnitPrice(product);
        }
        public bool AddSales(Sales sales)
        {
            return _salesRepository.AddSales(sales);
        }



    }
}
