using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CustomerAccountSystem.Repository;
using CustomerAccountSystem.Models;

namespace CustomerAccountSystem.BBL
{
    public class TransactionManager
    {
        TransactionRepository _transactionRepository;
        public TransactionManager()
        {
            _transactionRepository = new TransactionRepository();
        }

        public DataTable GetAmount(Account account)
        {
            return _transactionRepository.GetAmount(account);
        }
        public int UpdateAccount(Account account)
        {
            return _transactionRepository.UpdateAccount(account);

        }
    }
}
