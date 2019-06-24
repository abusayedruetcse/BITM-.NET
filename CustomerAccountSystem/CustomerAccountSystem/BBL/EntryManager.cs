using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAccountSystem.Models;
using CustomerAccountSystem.Repository;

namespace CustomerAccountSystem.BBL
{
    public class EntryManager
    {
        EntryRepository _entryRepository;
        public EntryManager()
        {
            _entryRepository = new EntryRepository();
        }
        public bool IsAccountNoDuplicate(Customer customer)
        {
            return _entryRepository.IsAccountNoDuplicate(customer);
        }
        public int InsertEntry(Customer customer)
        {
            return _entryRepository.InsertEntry(customer);
        }
        public void InsertAmount(Account account)
        {
            _entryRepository.InsertAmount(account);
        }
    }
}
