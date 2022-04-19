using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Database.Balance.Models;
using Database.Balance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Site.Balance.Controllers
{
    public class UnitPositionsController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public UnitPositionsController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var databaseBalanceContext = _context.UnitPositions.Include(u => u.Unit);
            return View(await databaseBalanceContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitPositionModel = await _context.UnitPositions
                .Include(u => u.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitPositionModel == null)
            {
                return NotFound();
            }

            return View(unitPositionModel);
        }

        public IActionResult Create()
        {
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
            return View(new UnitPositionModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitPositionModel unitPositionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitPositionModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", unitPositionModel.UnitId);
            return View(unitPositionModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitPositionModel = await _context.UnitPositions.FindAsync(id);

            if (unitPositionModel == null)
            {
                return NotFound();
            }

            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", unitPositionModel.UnitId);
            return View(unitPositionModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UnitPositionModel unitPositionModel)
        {
            if (id != unitPositionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitPositionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitPositionModelExists(unitPositionModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", unitPositionModel.UnitId);
            return View(unitPositionModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitPositionModel = await _context.UnitPositions
                .Include(u => u.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitPositionModel == null)
            {
                return NotFound();
            }

            return View(unitPositionModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitPositionModel = await _context.UnitPositions.FindAsync(id);

            _context.UnitPositions.Remove(unitPositionModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool UnitPositionModelExists(int id)
        {
            return _context.UnitPositions.Any(e => e.Id == id);
        }
    }
}
