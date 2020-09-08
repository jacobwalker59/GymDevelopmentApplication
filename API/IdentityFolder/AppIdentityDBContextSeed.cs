using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.IdentityFolder
{
    public class AppIdentityDBContextSeed
    {
        public static async Task SeedAll(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            await SeedUserData(userManager);
            await SeedRoles(roleManager);
        }
        public static async Task SeedUserData(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser{
                    DisplayName = "Jacob",
                    Email = "jacobwalkr59@gmail.com",
                    UserName = "jacob@test.com"

                };
                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }

        public static async Task SeedRoles(RoleManager<AppRole> roleManager)
        {
            if(roleManager.Roles.Any())
            {
                AppRole role = new AppRole();
                   role.Name = "NormalUser";
                   role.Description = "Perform normal operations.";
                   await roleManager.CreateAsync(role);
                  
            }
             
            if (!roleManager.RoleExistsAsync
            ( "Administrator").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Administrator";
                role.Description = "Perform all the operations.";
                await roleManager.CreateAsync(role);
            }
            
                
            }
        }
}
