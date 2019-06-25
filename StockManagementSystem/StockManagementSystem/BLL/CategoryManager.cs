using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Repository;
using StockManagementSystem.Models;
using System.Data;
namespace StockManagementSystem.BLL
{
    class CategoryManager
    {
        CategoryRepository _categoryRepository;
        public CategoryManager()
        {
            _categoryRepository = new CategoryRepository();
        }
        public int Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
        public DataTable Display()
        {
            return _categoryRepository.Display();
        }
        public int Insert(Category category)
        {
            return _categoryRepository.Insert(category);
        }
    }
}
