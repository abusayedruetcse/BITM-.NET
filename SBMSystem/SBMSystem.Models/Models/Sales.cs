using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystem.Models.Models
{
    public class Sales
    {
        public string CustomerCode { get; set; }
        public string Date { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public double PayableAmount { get; set; }
        //
        public int SL { get; set; }
        public string Product { get; set; }
        public double TotalPrice { get; set; }
        public double UnitPrice { get; set; }
        public string Action { get { return "Delete"; } }        
    }
}
