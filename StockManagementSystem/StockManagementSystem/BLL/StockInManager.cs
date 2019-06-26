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
    }
}
