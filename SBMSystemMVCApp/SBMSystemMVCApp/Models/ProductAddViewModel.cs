using SBMSystemMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSystemMVCApp.Models
{
    public class ProductAddViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ReorderLevel { get; set; }
        public string ImageProduct { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}