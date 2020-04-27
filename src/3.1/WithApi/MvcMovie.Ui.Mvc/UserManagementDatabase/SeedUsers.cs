using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MvcMovie.Ui.Mvc.UserManagementDatabase
{
    public static class SeedUsers
    {
        internal static async Task InitializeAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            // Set password with the Secret Manager tool.
            // dotnet user-secrets set SeedUserPW <pw>

            var adminUserEmail = configuration["AdminUserEmail"];
            var adminUserPw = configuration["AdminUserPw"];
            await using var context = serviceProvider.GetRequiredService<UserManagementDbContext>();

            var adminId = await EnsureUserAsync(serviceProvider, adminUserEmail, adminUserPw).ConfigureAwait(false);
            await EnsureRoleAsync(serviceProvider, adminId, "Admin").ConfigureAwait(false);

            var userEmail = configuration["UserEmail"];
            var userPw = configuration["UserPw"];
            var userId = await EnsureUserAsync(serviceProvider, userEmail, userPw).ConfigureAwait(false);
            await EnsureRoleAsync(serviceProvider, userId, "User").ConfigureAwait(false);
        }

        private static async Task<string> EnsureUserAsync(IServiceProvider serviceProvider,
            string userName, string userPw)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = userName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, userPw).ConfigureAwait(false);
            }

            if (user == null) throw new Exception("The password is probably not strong enough!");

            return user.Id;
        }

        private static async Task EnsureRoleAsync(IServiceProvider serviceProvider,
            string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null) throw new Exception("roleManager null");

            if (!await roleManager.RoleExistsAsync(role).ConfigureAwait(false))
                await roleManager.CreateAsync(new IdentityRole(role)).ConfigureAwait(false);

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByIdAsync(uid).ConfigureAwait(false);

            if (user == null) throw new Exception("The testUserPw password was probably not strong enough!");

            await userManager.AddToRoleAsync(user, role).ConfigureAwait(false);
        }
    }
}