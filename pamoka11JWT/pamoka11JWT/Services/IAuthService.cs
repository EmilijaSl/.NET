using pamoka11JWT.Models;

namespace pamoka11JWT.Services
{
    public interface IAuthService
    {
        Task<(bool authentificaltionSuccesfull, string? role)> LoginAsync(string username, string password);
        Task<Accaunt> SignupNewAccauntAsync(string username, string password);
    }
}
