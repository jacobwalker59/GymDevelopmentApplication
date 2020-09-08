using API.IdentityFolder;

namespace API.Data.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
    }
}