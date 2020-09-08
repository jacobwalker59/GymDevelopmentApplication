using Microsoft.AspNetCore.Identity;

namespace API.IdentityFolder
{
    public class AppUser:IdentityUser
    {
        public string DisplayName {get;set;}
    }
}