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
    public class ViewManager
    {
        ViewRepository _viewRepository;
        public ViewManager()
        {
            _viewRepository = new ViewRepository();
        }
        public DataTable LoadStockOutToDataGridView(string fromDate, string toDate, string action)
        {
            return _viewRepository.LoadStockOutToDataGridView(fromDate, toDate, action);
        }
    }
}
