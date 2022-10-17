using FullStackDomain;

namespace FullStackBL
{
    public interface IJwtService
    {
        string GetJwtToken(UserAccount userAccount);
    }
}
