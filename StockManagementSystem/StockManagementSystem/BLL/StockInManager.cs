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
    public class StockInManager
    {
        StockInRepository _stockInRepository;
        public StockInManager()
        {
            _stockInRepository = new StockInRepository();
        }
        public DataTable LoadCompanyToComboBox()
        {
            return _stockInRepository.LoadCompanyToComboBox();
        }
        public DataTable LoadCategoryToComboBox()
        {
            return _stockInRepository.LoadCategoryToComboBox();
        }
        public DataTable LoadFilteredItemToComboBox(int categoryID, int companyID)
        {
            return _stockInRepository.LoadFilteredItemToComboBox(categoryID, companyID);
        }
        public void UpdateItem(Item item)
        {
            _stockInRepository.UpdateItem(item);
        }
        public void UpdateStockIn(StockIn stockIn)
        {
            _stockInRepository.UpdateStockIn(stockIn);
        }
        public int InsertStockIn(StockIn stockIn)
        {
            return _stockInRepository.InsertStockIn(stockIn);
        }
        public DataTable GetItem(Item item)
        {
            return _stockInRepository.GetItem(item);
        }
        public DataTable DisplayRecords()
        {
            return _stockInRepository.DisplayRecords();
        }
        public DataTable GetAvailableQuantityAndReorderLevel(int categoryID, int companyID, string itemName)
        {
            return _stockInRepository.GetAvailableQuantityAndReorderLevel(categoryID, companyID, itemName);
        }

    }
}
