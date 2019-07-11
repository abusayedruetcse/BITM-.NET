using SBMSystem.Models.Models;
using SBMSystem.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystem.BLL.BLL
{
    public class SupplierManager
    {        
        SupplierRepository _supplierRepository;
        public SupplierManager()
        {
            _supplierRepository = new SupplierRepository();
        }
        public bool AddSupplier(Supplier supplier)
        {
            return _supplierRepository.AddSupplier(supplier);
        }
        public bool IsCodeDuplicate(Supplier supplier)
        {
            return _supplierRepository.IsCodeDuplicate(supplier);
        }
    }
}
