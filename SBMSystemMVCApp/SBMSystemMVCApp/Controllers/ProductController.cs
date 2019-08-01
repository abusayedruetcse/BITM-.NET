using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSystemMVCApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Add()
        {
            return View();
        }
    }
}