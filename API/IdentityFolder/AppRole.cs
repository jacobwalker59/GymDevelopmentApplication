using Microsoft.AspNetCore.Identity;

namespace API.IdentityFolder
{
    public class AppRole:IdentityRole
    {
        public string Description {get;set;}
    }
}