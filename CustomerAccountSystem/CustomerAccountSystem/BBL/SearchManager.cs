using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAccountSystem.Models;
using CustomerAccountSystem.Repository;
using System.Data;

namespace CustomerAccountSystem.BBL
{
    public class SearchManager
    {
        SearchRepository _searchRepository;
        public SearchManager()
        {
            _searchRepository = new SearchRepository();
        }
        public DataTable ShowCustomer(Customer customer)
        {
            return _searchRepository.ShowCustomer(customer);
        }
    }
}
