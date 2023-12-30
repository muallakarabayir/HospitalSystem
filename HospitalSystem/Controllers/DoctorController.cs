using HospitalData;
using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace HospitalSystem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HospitalDataContext _context;
        public DoctorController(HospitalDataContext context)
        {
            _context = context;
        }
        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            return _context.Doctors != null ?
                          View(await _context.Doctors.ToListAsync()) :
                          Problem("Entity set 'HospitalDataContext.Doctors'  is null.");
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            ViewBag.Branches = _context.Branches.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.Policlinics = _context.Policlinics.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,BranchId,PoliclinicId")] Doctor doctor)
        {
            if (ModelState.IsValid ||true)
            {
                var branchForDoctor = _context.Branches.FirstOrDefault(i => i.Id == doctor.BranchId);
                var policlinicForDoctor= _context.Policlinics.FirstOrDefault( i => i.Id ==doctor.PoliclinicId);
                
                
                Doctor doctorEntity = new Doctor
                {
                    Name= doctor.Name,
                    Surname= doctor.Surname,
                    Branch=branchForDoctor ,
                    policlinic=policlinicForDoctor
                };

                _context.Add(doctorEntity);
                _context.SaveChangesAsync();
            }
            
            return View();
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
