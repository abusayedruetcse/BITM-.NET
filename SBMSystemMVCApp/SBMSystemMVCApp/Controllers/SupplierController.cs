using SBMSystemMVCApp.BLL.BLL;
using SBMSystemMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSystemMVCApp.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager;
        public SupplierController()
        {
            _supplierManager = new SupplierManager();
        }
        // GET: Supplier
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (_supplierManager.IsCodeDuplicate(supplier))
                {
                    ViewBag.FailMsg = "Code is Duplicate";
                    return View();
                }
                if (_supplierManager.Add(supplier))
                {
                    ViewBag.SuccessMsg = "Successfully Saved";
                }
                else
                {
                    ViewBag.FailMsg = "Save Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }
            return View();
        }
    }
}