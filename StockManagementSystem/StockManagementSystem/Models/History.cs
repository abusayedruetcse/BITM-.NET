﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Models
{
    public class History
    {
        public int UserID { get; set; }
        public string TableName { get; set; }
        public int TableRowNo { get; set; }
        public string Element { get; set; }
        public string DateAndTime { get; set; }
    }
}
