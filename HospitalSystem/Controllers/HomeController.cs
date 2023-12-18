using HospitalData;
using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HospitalSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalDataContext context;
      
        public HomeController(HospitalDataContext context)
        {

            this.context = context;
            
        }

        public IActionResult Index()
        {
            var users = this.context.Users.Include(m => m.Appointments).Select(m => new UsersViewModel
            {
               Id = m.Id,
               Name = m.Name,
               Surname = m.Surname,
               Email = m.Email,
               IdentityNo=m.IdentityNo,
               Phone=m.Phone

            });
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}