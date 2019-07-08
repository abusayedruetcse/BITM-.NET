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
        public DataTable IsUpdateCategoryDuplicate(Category category)
        {
            return _categoryRepository.IsUpdateCategoryDuplicate(category);
        }
        public bool IsCategoryDuplicate(Category category)
        {
            return _categoryRepository.IsCategoryDuplicate(category);
        }
        public int Update(Category category,History history)
        {
            return _categoryRepository.Update(category,history);
        }
        public DataTable Display()
        {
            return _categoryRepository.Display();
        }
        public int Insert(Category category,History history)
        {
            return _categoryRepository.Insert(category,history);
        }
    }
}
