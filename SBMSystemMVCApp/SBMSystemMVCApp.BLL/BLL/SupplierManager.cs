using SBMSystemMVCApp.Models.Models;
using SBMSystemMVCApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystemMVCApp.BLL.BLL
{
    public class SupplierManager
    {        
        SupplierRepository _supplierRepository;
        public SupplierManager()
        {
            _supplierRepository = new SupplierRepository();
        }
        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }
        public bool IsCodeDuplicate(Supplier supplier)
        {
            return _supplierRepository.IsCodeDuplicate(supplier);
        }
    }
}
