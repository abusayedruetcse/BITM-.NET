using SBMSystemMVCApp.Models.Models;
using SBMSystemMVCApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystemMVCApp.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository;
        public PurchaseManager()
        {
            _purchaseRepository = new PurchaseRepository();
        }
        public List<Supplier> GetSuppliers()
        {
            return _purchaseRepository.GetSuppliers();
        }
        public List<Product> GetProducts()
        {
            return _purchaseRepository.GetProducts();
        }
        public bool AddPurchase(Purchase purchase)
        {
            return _purchaseRepository.AddPurchase(purchase);
        }
        public int GetAvailableQuantity(Product product)
        {
            return _purchaseRepository.GetAvailableQuantity(product);
        }
        public bool UpdateProduct(Product product)
        {
            return _purchaseRepository.UpdateProduct(product);
        }
    }
}
