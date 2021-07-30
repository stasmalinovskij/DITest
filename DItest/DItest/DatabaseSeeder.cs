using DItest.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DItest
{
    public class DatabaseSeeder
    {
        private ApplicationDbContext context;
        private SeedData options;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DatabaseSeeder(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<SeedData> options)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.options = options.Value;
        }

        public async Task SeedAsync()
        {
            await SeedAdminUser();
        }

        private async Task SeedAdminUser()
        {
            var adminRole = await roleManager.FindByNameAsync(options.AdminRoleName);
            if (adminRole == null)
            {
                adminRole = new IdentityRole(options.AdminRoleName);
                var result = await roleManager.CreateAsync(adminRole);
                if (!result.Succeeded)
                {
                    throw new Exception($"Can't create admin role: {string.Join(", ", result.Errors.Select(e => $"{e.Code}:{e.Description}"))}");
                }
            }

            var adminUserToRole = await context.UserRoles.FirstOrDefaultAsync(ur => ur.RoleId == adminRole.Id);

            if (adminUserToRole == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = options.AdministratorUserName,
                    Email = options.AdministratorEmail,
                    EmailConfirmed = true,
                };
                var userCreateResult = await userManager.CreateAsync(adminUser, options.AdministratorPassword);
                if (!userCreateResult.Succeeded)
                {
                    throw new Exception($"Can't create admin user: {string.Join(", ", userCreateResult.Errors.Select(e => $"{e.Code}:{e.Description}"))}");
                }
                await userManager.AddToRoleAsync(adminUser, adminRole.Name);
            }
        }

    }
}
