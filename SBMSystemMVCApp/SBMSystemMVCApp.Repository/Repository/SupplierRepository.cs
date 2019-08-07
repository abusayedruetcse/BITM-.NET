using SBMSystemMVCApp.DatabaseContext.DatabaseContext;
using SBMSystemMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystemMVCApp.Repository.Repository
{
    public class SupplierRepository
    {
        SBMSystemDbContext db;
        public SupplierRepository()
        {
            db = new SBMSystemDbContext();
        }
        public bool Add(Supplier supplier)
        {
            int isExecuted = 0;
            db.Suppliers.Add(supplier);
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        }
        public bool IsCodeDuplicate(Supplier supplier)
        {
            var aSupplier = db.Suppliers.FirstOrDefault(c => c.Code == supplier.Code);
            if(aSupplier!=null)
            {
                return true;
            }
            return false;
        }
        public List<Supplier> GetAll()
        {
            var suppliers = db.Suppliers.ToList();
            return suppliers;
        }
        public Supplier GetById(int id)
        {
            var supplier = db.Suppliers.FirstOrDefault(c => c.Id == id);
            return supplier;
        }
        public bool isUpdated(Supplier supplier)
        {
            int isExecuted = 0;
            db.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
        }
    }
}
