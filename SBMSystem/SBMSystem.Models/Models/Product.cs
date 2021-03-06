﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystem.Models.Models
{
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public int ReorderLevel { get; set; }
        public string ImageProduct { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public int CurrentMRP { get; set; }
        public int UnitPrice { get; set; }

    }
}
