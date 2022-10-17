using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public interface IDbRepository
    {
        List<Account> GetAllAccounts();
        void AddAccount(Account account);
        void Commit();
        Account GetAccountById(int id);
        void UpdateAccount(Account account);
        void DeleteAccount(int id);
    }
}
