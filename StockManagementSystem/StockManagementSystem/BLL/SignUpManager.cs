using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Models;
using StockManagementSystem.Repository;

namespace StockManagementSystem.BLL
{
    public class SignUpManager
    {
        SignUpRepository _signUpRepository;
        public SignUpManager()
        {
            _signUpRepository = new SignUpRepository();
        }
        public bool IsUserAccountCreated()
        {
            return _signUpRepository.IsUserAccountCreated();
        }
        public bool IsPasswordUnique()
        {
            return _signUpRepository.IsPasswordUnique();
        }
    }
}
