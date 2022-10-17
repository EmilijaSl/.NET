namespace pamoka11JWT.Services
{
    public interface IJwtService
    {
        string GetJwtToken(string username, string role);
    }
}
