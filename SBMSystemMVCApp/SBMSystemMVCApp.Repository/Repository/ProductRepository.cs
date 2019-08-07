using SBMSystemMVCApp.DatabaseContext.DatabaseContext;
using SBMSystemMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystemMVCApp.Repository.Repository
{
    public class ProductRepository
    {
        SBMSystemDbContext db;
        public ProductRepository()
        {
            db = new SBMSystemDbContext();
        }
        public List<Category> GetCategories()
        {
            var categories = db.Categories.ToList();
            return categories;
        }
        public bool AddProduct(Product product)
        {
            int isExecuted = 0;
            db.Products.Add(product);
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        } 
        public List<Product> GetProducts()
        {
            var products = db.Products.ToList();
            return products;
        }
        public bool UpdateProduct(Product product)
        {
            int isExecuted = 0;
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        }
        public bool DeleteProduct(Product product)
        {
            int isExecuted = 0;
            var aProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);
            if(aProduct!=null)
            {
                db.Products.Remove(aProduct);
                isExecuted = db.SaveChanges();
            }
            return isExecuted > 0;
        }

        public bool isUpdated(Product aProduct)
        {
            int isExecuted = 0;
            db.Entry(aProduct).State = System.Data.Entity.EntityState.Modified;
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        }

        public Product GetById(int id)
        {
            return db.Products.FirstOrDefault(c => c.Id == id);
        }

        public bool IsCodeDuplicate(Product product)
        {
            bool isDuplicate = false;
            var aProduct = db.Products.FirstOrDefault(p => p.Code == product.Code);
            if(aProduct!=null)
            {
                isDuplicate = true;
            }
            return isDuplicate;
        }

    }
}
