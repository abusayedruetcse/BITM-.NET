using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using StockManagementSystem.Repository;
using StockManagementSystem.Models;

namespace StockManagementSystem.BLL
{
    public class CompanyManager
    {
        CompanyRepository _companyRepository;
        public CompanyManager()
        {
            _companyRepository = new CompanyRepository();
        }

        public DataTable Display()
        {
            return _companyRepository.Display();
        }
        public int Insert(Company company,History history)
        {
            return _companyRepository.Insert(company,history);
        }
        public int Update(Company company,History history)
        {
            return _companyRepository.Update(company,history);
        }
    }
}
