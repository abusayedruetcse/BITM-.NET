using SBMSystem.Models.Models;
using SBMSystem.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystem.BLL.BLL
{
    public class CategoryManager
    {
        Category category;
        CategoryRepository _categoryRepository;
        public CategoryManager()
        {
            category = new Category();
            _categoryRepository = new CategoryRepository();
        }
        public string AddCategory(string code,string name)
        {
            return _categoryRepository.AddCategory(code, name);
        }
    }
}
