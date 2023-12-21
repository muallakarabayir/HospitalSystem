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
            ViewBag.BranchList = new SelectList(_context.Branches, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Branch.Id")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor    );
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.BranchList = new SelectList(_context.Branches, "Id", "Name", doctor.Branch);
            return View(doctor);
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
