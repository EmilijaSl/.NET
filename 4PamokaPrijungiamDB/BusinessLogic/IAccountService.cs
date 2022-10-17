using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IAccountService
    {
        List<Account> GetAllAccounts();
        int AddAccount(Account account);
        Account GetAccountById(int id);
        void UpdateAccount(Account account);
        void DeleteAccount(int id);
    }
}
