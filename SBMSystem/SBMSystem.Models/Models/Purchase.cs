using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystem.Models.Models
{
    public class Purchase
    {
        public string SupplierCode { get;set;}
        public string BillNo { get;set;}
        public string Date { get;set;}
        public string ProductCode { get;set;}
        public string ManufacturedDate { get;set;}
        public string ExpireDate { get;set;}
        public int Quantity { get;set;}
        public int UnitPrice { get;set;}
        public int MRP { get;set;}
        public string Remarks { get; set; }
        //
        public int SL { get; set; }
        public double TotalPrice { get; set; }
        public string EditAction { get { return "Edit"; } }
        public string DeleteAction { get { return "Delete"; } }
    }
}
