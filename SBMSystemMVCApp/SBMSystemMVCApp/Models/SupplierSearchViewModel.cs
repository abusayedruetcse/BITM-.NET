﻿using SBMSystemMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBMSystemMVCApp.Models
{
    public class SupplierSearchViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string ImageSupplier { get; set; }
        public int ContactPerson { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}