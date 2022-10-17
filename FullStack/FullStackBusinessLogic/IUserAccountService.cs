using FullStackDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackBL
{
    public interface IUserAccountService
    {
        Task<bool> CreateUserAccountAsync(string userName, string password, List<ContactDetail> contactDetails);
        Task<(bool authentificationSuccesful, UserAccount? userAccount)> LoginAsync(string username, string password);

    }
}
