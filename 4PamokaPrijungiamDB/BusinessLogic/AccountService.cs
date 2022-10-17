using DataAcces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AccountService :IAccountService
    {
        private readonly IDbRepository _repository;
        public AccountService(IDbRepository repository)
        {
            _repository = repository;
        }
        public List<Account> GetAllAccounts()
        { 
        return _repository.GetAllAccounts();
        }
        public int AddAccount(Account account)
        { 
        _repository.AddAccount(account);
            _repository.Commit();

            return account.Id;
        }
        public Account GetAccountById(int id)
        { 
        return _repository.GetAccountById(id);
        }
        public void UpdateAccount(Account account)
        { 
        var accountFromDb = _repository.GetAccountById(account.Id);
            if (accountFromDb == null)
            {
                throw new ArgumentException($"Couldn't find account by Id {account.Id}");
            }
            _repository.UpdateAccount(account);
            _repository.Commit();
        }
        public void DeleteAccount(int id)
        {
            _repository.DeleteAccount(id);
            _repository.Commit();
        }
    }
}
