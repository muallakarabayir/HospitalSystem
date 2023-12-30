using HospitalData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Controllers
{
    public class BranchController : Controller
    {
        private readonly HospitalDataContext _context;
        public BranchController(HospitalDataContext context)
        {
            _context = context;
        }
        // GET: BranchController
        public async Task<IActionResult> Index()
        {
            return _context.Branches != null ?
                          View(await _context.Branches.ToListAsync()) :
                          Problem("Entity set 'HospitalDataContext.Branches'  is null.");
        }
    

        // GET: BranchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BranchController/Create
        public ActionResult Create()
        {

            
            return View();
        }

        // POST: BranchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Branch branch)
        {
            if (ModelState.IsValid || true)
            {
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }


        // GET: BranchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BranchController/Edit/5
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
            if (id == null || _context.Branches == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: AuthorAuto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Branches == null)
            {
                return Problem("Entity set 'WABookStoreContext.Authors'  is null.");
            }
            var branch= await _context.Branches.FindAsync(id);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
