using HospitalData;
using HospitalSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.HospitalUtilities
{
    public class DbInitializer : IDbInitializer
    { private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private HospitalDataContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            HospitalDataContext context)
        {
            _roleManager = roleManager;
        }

        public void Initialize()
        {
           try
            {
                if(_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception){


                throw;
            }
            if(!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult()) 
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "naz",
                    Email = "naz@gmail.com"

                },"naz@gmail.com").GetAwaiter().GetResult(); 
                var appUser=_context.ApplicationUsers.FirstOrDefault(x=>x.Email=="naz@gmail.com");
                if (appUser != null)
                {
                    _userManager.AddToRoleAsync(appUser,WebSiteRoles.WebSite_Admin);
                }
                
            }
        }
    }
}
