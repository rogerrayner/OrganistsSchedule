using Microsoft.AspNetCore.Identity;
using OrganistsSchedule.Domain.Identity;
using OrganistsSchedule.Infra.Data.Identity;

namespace OrganistsSchedule.Infrastructure.Seeds.Identity;

public class UserRoleSeed(UserManager<UserIdentity> userManager/*, RoleManager<IdentityRole> roleManager*/)
    : ISeedUserRoleInitial
{
    private readonly UserManager<UserIdentity> _userManager = userManager;
    //private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    
    public void SeedUsers()
    {
        if (_userManager.FindByEmailAsync("admin@admin").Result == null)
        {
            var user = new UserIdentity
            {
                Email = "admin@admin.com.br",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@ADMIN",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            
            var result = _userManager.CreateAsync(user, "admin@123").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
            
        }
    }

    public void SeedRoles()
    {
        /*if (_roleManager.FindByNameAsync("Admin").Result == null)
        {
            var role = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
                
            };
            
            _roleManager.CreateAsync(role);
        }
        
        if (_roleManager.FindByNameAsync("Default").Result == null)
        {
            var role = new IdentityRole
            {
                Name = "Default",
                NormalizedName = "DEFAULT"
                
            };
            
            _roleManager.CreateAsync(role);
        }*/
    }
}