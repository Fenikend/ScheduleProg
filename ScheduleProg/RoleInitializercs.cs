using ScheduleProg.Models; 
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ScheduleProg
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "Axi$&ombre2";
            string password2 = "Axi$&ombre22";
            string firstname = "Grigor";
            string lastname = "Abusi";


            if (await roleManager.FindByNameAsync("Адміністратор") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Адміністратор"));
            }
            if (await roleManager.FindByNameAsync("Вчитель") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Вчитель"));
            }
            if (await roleManager.FindByNameAsync("Студент") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Студент"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail ,First_Name=firstname,Last_Name=lastname};
               IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Адміністратор");
                }
                
            }

        }
    }
}