using SBMSystemMVCApp.BLL.BLL;
using SBMSystemMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSystemMVCApp.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        PurchaseAddViewModel purchaseavm;
        PurchaseManager _purchaseManager;
        ProductManager _productManager;
        public PurchaseController()
        {
            _purchaseManager = new PurchaseManager();
            _productManager = new ProductManager();
        }
        [HttpGet]
        public ActionResult Add()
        {
            purchaseavm = new PurchaseAddViewModel();
            var supplierListItem= _purchaseManager.GetSuppliers().Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = s.Name }).ToList();
            supplierListItem.Insert(0, new SelectListItem() { Value = "", Text = "Select..." });
            purchaseavm.SupplierListItem = supplierListItem;
            var productListItem = _purchaseManager.GetProducts().Select(p => new SelectListItem() { Value = p.Id.ToString(), Text = p.Name }).ToList();
            productListItem.Insert(0, new SelectListItem() { Value = "", Text = "Select..." });
            purchaseavm.ProductListItem = productListItem;
            return View(purchaseavm);
        }
        [HttpPost]
        public ActionResult Add(PurchaseAddViewModel purchaseavm)
        {
            //purchaseavm = new PurchaseAddViewModel();
            //var supplierListItem = _purchaseManager.GetSuppliers().Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = s.Name }).ToList();
            //supplierListItem.Insert(0, new SelectListItem() { Value = "", Text = "Select..." });
            //purchaseavm.SupplierListItem = supplierListItem;
            //var productListItem = _purchaseManager.GetProducts().Select(p => new SelectListItem() { Value = p.Id.ToString(), Text = p.Name }).ToList();
            //productListItem.Insert(0, new SelectListItem() { Value = "", Text = "Select..." });
            //purchaseavm.ProductListItem = productListItem;
            return View(purchaseavm);
        }
        public JsonResult GetProduct(int productId)
        {
            var aProduct = _productManager.GetById(productId);            
            return Json(aProduct, JsonRequestBehavior.AllowGet);
        }
        
    }
}