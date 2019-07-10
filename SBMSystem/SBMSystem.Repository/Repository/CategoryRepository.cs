using SBMSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystem.Repository.Repository
{
    public class CategoryRepository
    {
        Category category;
        public CategoryRepository()
        {
            category = new Category();
        }
        public string AddCategory(string code, string name)
        {
            category.Name = name;
            category.Code = code;
            return "Code: " + category.Code + Environment.NewLine + "Name: " + category.Name;
        }
    }
}
