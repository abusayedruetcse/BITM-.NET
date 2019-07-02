using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using StockManagementSystem.Models;
using StockManagementSystem.Repository;

namespace StockManagementSystem.BLL
{
    public class StockOutManager
    {
        StockOutRepository _stockOutRepository;
        public StockOutManager()
        {
            _stockOutRepository = new StockOutRepository();
        }
        public DataTable LoadCompanyToComboBox()
        {
            return _stockOutRepository.LoadCompanyToComboBox();
        }
        public DataTable LoadFilteredCompanyToComboBox(int categoryID)
        {
            return _stockOutRepository.LoadFilteredCompanyToComboBox(categoryID);
        }
        public DataTable LoadCategoryToComboBox()
        {
            return _stockOutRepository.LoadCategoryToComboBox();
        }
        public DataTable LoadFilteredCategoryToComboBox(int companyID)
        {
            return _stockOutRepository.LoadFilteredCategoryToComboBox(companyID);
        }
        public DataTable LoadFilteredItemToComboBox(int categoryID, int companyID)
        {
            return _stockOutRepository.LoadFilteredItemToComboBox(categoryID, companyID);
        }
        public DataTable GetAvailableQuantityAndReorderLevel(Item item)
        {
            return _stockOutRepository.GetAvailableQuantityAndReorderLevel(item);
        }
        public int InsertStockOut(StockOut stockOut)
        {
            return _stockOutRepository.InsertStockOut(stockOut);
        }
        public DataTable GetItem(Item item)
        {
            return _stockOutRepository.GetItem(item);
        }
        public void UpdateItem(Item item)
        {
            _stockOutRepository.UpdateItem(item);
        }
    }
}
