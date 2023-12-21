using HospitalData;
using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;



namespace HospitalSystem.Controllers
{
    
    public class AppointmentController:Controller
    {
        private readonly HospitalDataContext context;
        public AppointmentController(HospitalDataContext context)
        {

            this.context = context;

        }
        public IActionResult Index()
        {
            // Fetch policlinic names from the database
            var policlinicNames = context.Policlinics.Select(p => p.Name).ToList();

            ViewData["PoliclinicNames"] = policlinicNames;


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
