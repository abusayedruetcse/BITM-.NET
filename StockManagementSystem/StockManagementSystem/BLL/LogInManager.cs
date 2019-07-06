using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Models;
using StockManagementSystem.Repository;

namespace StockManagementSystem.BLL
{
    public class LogInManager
    {
        LogInRepository _logInRepository;
        public LogInManager()
        {
            _logInRepository = new LogInRepository();
        }

        public bool IsUserValid()
        {
            return _logInRepository.IsUserValid();
        }
    }
}
