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
    public class CategoryManager
    {
        CategoryRepository _categoryRepository;
        public CategoryManager()
        {
            _categoryRepository = new CategoryRepository();
        }
        public bool AddCategory(Category category)
        {
            return _categoryRepository.AddCategory(category);
        }
        public bool UpdateCategory(Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }
        public bool DeleteCategory(Category category)
        {
            return _categoryRepository.DeleteCategory(category);
        }
        public DataTable GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
    }
}
