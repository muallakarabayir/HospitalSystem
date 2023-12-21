using HospitalData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Controllers
{
    public class PoliclinicsController : Controller
    {
        private readonly HospitalDataContext _context;
        public PoliclinicsController(HospitalDataContext context)
        {
            _context = context;
        }
        // GET: PoliclinicsController
        public async Task<IActionResult> Index()
        {
            return _context.Policlinics != null ?
                          View(await _context.Policlinics.ToListAsync()) :
                          Problem("Entity set 'HospitalDataContext.Policlinics'  is null.");
        }

        // GET: PoliclinicsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PoliclinicsController/Create
    
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoliclinicsController/Create
        [HttpPost]

        public IActionResult Create([Bind("Id,Name")] Policlinic policlinic)
        {
            _context.Policlinics.Add(policlinic);
            _context.SaveChanges();
            return RedirectToAction("Create");

        }

        // GET: PoliclinicsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PoliclinicsController/Edit/5
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

        // GET: AuthorAuto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Policlinics == null)
            {
                return NotFound();
            }

            var policlinic = await _context.Policlinics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policlinic == null)
            {
                return NotFound();
            }

            return View(policlinic);
        }

        // POST: AuthorAuto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Policlinics == null)
            {
                return Problem("Entity set 'HospitalDataContext.Policilinics'  is null.");
            }
            var policlinic = await _context.Policlinics.FindAsync(id);
            if (policlinic != null)
            {
                _context.Policlinics.Remove(policlinic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
