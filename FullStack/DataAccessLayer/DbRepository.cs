using FullStackDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackDAL
{
    public class DbRepository : IDbRepository
    {
        private readonly FullStackDbContext _dbContext;
        public DbRepository(FullStackDbContext context)
        {
            _dbContext = context;
        }

        public async Task<UserAccount?> GetAccountByUserNameAsync(string username) //klaustukas reiskia akd gali grizti ir nullas
        {
            return await _dbContext.UserAccounts.SingleOrDefaultAsync(u=>u.UserName == username);

        }

        public async Task InsertAccountAsync(UserAccount userAccount)
        {
            _dbContext.UserAccounts.Add(userAccount);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync(); 
        }
    }
}
