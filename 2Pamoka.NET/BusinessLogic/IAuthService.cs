using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IAuthService
    {
        Task<(bool authentificaltionSuccesfull, string? role)> LoginAsync(string username, string password);
        Task<Accaunt> SignupNewAccauntAsync(string username, string password);
        Task<Accaunt> SaveUpdated(int id, string role);
     


    }
}
