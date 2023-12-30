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
        public async Task<IActionResult> Index()
        {
            return _context.Appointments != null ?
                          View(await _context.Appointments.ToListAsync()) :
                          Problem("Entity set 'HospitalDataContext.Appointments'  is null.");
        }

        [HttpGet]
        public IActionResult GetDoctorsByPoliclinic(int policlinicId)
        {
            var doctors = _context.Doctors
                .Where(d => d.PoliclinicId == policlinicId)
                .Select(d => new
                {
                    Id = d.Id,
                    Name = d.Name,
                    Surname = d.Surname
                })
                .ToList();

            return Json(doctors);
        }

        public ActionResult Create(int policlinicId)
        {
            ViewBag.Policlinics = _context.Policlinics.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.Doctors = new List<SelectListItem>();

            return View();
        }

        // POST: BranchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,PoliclinicId")] Appointment appointment)
        {
            if (ModelState.IsValid || true)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ModelState.IsValid false ise, formda hata var demektir
            // Bu durumda, view'e tekrar formu göndermek daha uygun olacaktır
            ViewBag.Policlinics = _context.Policlinics.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            // Seçilen poliklinik ID'sine bağlı olarak doktorları getirip ViewBag'e ekleyin
            if (appointment.PoliclinicId > 0)
            {
                var doctors = _context.Doctors.Where(d => d.PoliclinicId == appointment.PoliclinicId).Select(d => new SelectListItem
                {
                    Text = $"{d.Name} {d.Surname}",
                    Value = d.Id.ToString()
                });
                ViewBag.Doctors = doctors;
            }
            else
            {
                // Eğer poliklinik seçilmediyse, doktorları boş bırakın
                ViewBag.Doctors = new List<SelectListItem>();
            }

          
            return View(appointment);
        }
        [HttpPost]


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
