using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Repository;

namespace StockManagementSystem.BLL
{
    public class SystemSetupManager
    {
        SystemSetupRepository _systemSetupRepository;
        public SystemSetupManager()
        {
            _systemSetupRepository = new SystemSetupRepository();
        }
        public void Execute(string command)
        {
            _systemSetupRepository.Execute(command);
        }
    }
}
