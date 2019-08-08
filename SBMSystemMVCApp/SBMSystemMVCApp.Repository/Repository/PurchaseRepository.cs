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
    public class PurchaseRepository
    {
        SBMSystemDbContext db;
        public PurchaseRepository()
        {
            db = new SBMSystemDbContext();
        }
        public List<Supplier> GetSuppliers()
        {
            var suppliers = db.Suppliers.ToList();
            return suppliers;
        }
        public List<Product> GetProducts()
        {
            var products = db.Products.ToList();
            return products;
        }             
        public bool AddPurchase(Purchase purchase)
        {
            int isExecuted = 0;
            db.Purchases.Add(purchase);
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        } 
        public int GetAvailableQuantity(Product product)
        {
            
            return 0;
        }
        public bool UpdateProduct(Product product)
        {
            int isExecuted = 0;
            
            return isExecuted > 0;
        }


    }
}
