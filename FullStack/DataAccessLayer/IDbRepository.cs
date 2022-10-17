using FullStackDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackDAL
{
    public interface IDbRepository
    {
        Task<UserAccount?> GetAccountByUserNameAsync(string username);
        Task InsertAccountAsync(UserAccount userAccount);
        Task SaveChangesAsync(); //skirtas nusiusti i db 
    }
}
