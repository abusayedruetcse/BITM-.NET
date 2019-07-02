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
    public class SearchManager
    {
        SearchRepository _searchRepository;

        public SearchManager()
        {
            _searchRepository = new SearchRepository();
        }

        public DataTable LoadCompanyToComboBox()
        {
            return _searchRepository.LoadCompanyToComboBox();
        }
        public DataTable LoadCategoryToComboBox()
        {
            return _searchRepository.LoadCategoryToComboBox();
        }
        public DataTable LoadFilteredCategoryToComboBox(int companyID)
        {
            return _searchRepository.LoadFilteredCategoryToComboBox(companyID);
        }
        public DataTable LoadFilteredItemToDataGridView(int categoryID, int companyID, bool isCompanyLoaded, bool isCategoryLoaded)
        {
            return _searchRepository.LoadFilteredItemToDataGridView(categoryID, companyID, isCompanyLoaded, isCategoryLoaded);
        }
    }

    
    
}
