using CafeFlow.Entity;
using Microsoft.AspNetCore.Identity;

namespace CafeFlow.WebUI.Extensions
{
    public static class DataSeeder
    {
        public static async Task SeedRolesAndAdminAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });

            if (!await roleManager.RoleExistsAsync("Customer"))
                await roleManager.CreateAsync(new AppRole { Name = "Customer" });

            var admin = await userManager.FindByEmailAsync("admin@cafeflow.com");
            if (admin == null)
            {
                admin = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@cafeflow.com",
                    FirstName = "Admin",
                    LastName = "CafeFlow"
                };
                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
