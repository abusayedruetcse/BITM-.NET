using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Models;
using StockManagementSystem.Repository;
using System.Data;

namespace StockManagementSystem.BLL
{
    public class HistoryManagement
    {
        HistoryRepository _historyRepository;
        public HistoryManagement()
        {
            _historyRepository = new HistoryRepository();
        }
        public DataTable LoadCategoryCompanyItemHistory(string tableName)
        {
            return _historyRepository.LoadCategoryCompanyItemHistory(tableName);
        }
        public DataTable LoadStockInOutHistory(string tableName)
        {
            return _historyRepository.LoadStockInOutHistory(tableName);
        }
    }
}
