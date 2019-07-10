using SBMSystem.Models.Models;
using SBMSystem.Repository.Repository;
using System;
using System.Collections.Generic;
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
    }
}
