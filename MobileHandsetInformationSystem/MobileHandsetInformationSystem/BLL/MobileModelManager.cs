using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MobileHandsetInformationSystem.Repository;
using MobileHandsetInformationSystem.Models;

namespace MobileHandsetInformationSystem.BLL
{
    public class MobileModelManager
    {

        MobileModelRepositoy _mobileModelRepositoy;
        public MobileModelManager()
        {
           _mobileModelRepositoy = new MobileModelRepositoy();
        }
        public bool IsIMEIDuplicate(MobileModel mobileModel)
        {
            return _mobileModelRepositoy.IsIMEIDuplicate(mobileModel);
        }
        public int InsertModel(MobileModel mobileModel)
        {
            return _mobileModelRepositoy.InsertModel(mobileModel);
        }
        public DataTable SearchByPrice(string range1, string range2)
        {
            return _mobileModelRepositoy.SearchByPrice(range1, range2);
        }
    }
}
