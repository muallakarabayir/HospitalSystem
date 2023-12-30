using HospitalData;
using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;



namespace HospitalSystem.Controllers
{
    
    public class AppointmentController:Controller
    {
        private readonly HospitalDataContext _context;
        public AppointmentController(HospitalDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment , int selectedPoliclinicsId)
        {
         


            return View();
        }
        [HttpPost]


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
