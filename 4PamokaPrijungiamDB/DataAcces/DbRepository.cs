using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class DbRepository : IDbRepository
    {
        private readonly AplicationDbContext _context;
        public DbRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();   
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void AddAccount(Account account)
        { 
        _context.Add(account);
        }
        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }
        public void UpdateAccount(Account account)
        { 
        var accountFromDb = GetAccountById(account.Id);
        accountFromDb.Owner=account.Owner;
            accountFromDb.Balance = account.Balance;
            accountFromDb.CreatedTime = account.CreatedTime;
            accountFromDb.UpdateTime = account.UpdateTime;

        }
        public void DeleteAccount(int id)
        {
            var accountToRemove = GetAccountById(id);
            _context.Accounts.Remove(accountToRemove);
        }
    }
}
