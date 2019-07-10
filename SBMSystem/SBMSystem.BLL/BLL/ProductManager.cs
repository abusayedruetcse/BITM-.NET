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
    public class ProductManager
    {       
        ProductRepository _productRepository;
        public ProductManager()
        {
            _productRepository = new ProductRepository();
        }
        public DataTable LoadCategoryToComboBox()
        {
            return _productRepository.LoadCategoryToComboBox();
        }
        public bool AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }
        public DataTable GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}
