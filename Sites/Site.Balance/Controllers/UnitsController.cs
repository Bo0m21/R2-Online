using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database.Balance.Models;
using Database.Balance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Site.Balance.Controllers
{
    public class UnitsController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public UnitsController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Units.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitModel = await _context.Units
                .Include(m => m.UnitDrops)
                    .ThenInclude(m => m.Item)
                .Include(m => m.UnitPositions)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitModel == null)
            {
                return NotFound();
            }

            return View(unitModel);
        }

        public IActionResult Create()
        {
            return View(new UnitModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitModel unitModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(unitModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitModel = await _context.Units.FindAsync(id);

            if (unitModel == null)
            {
                return NotFound();
            }

            return View(unitModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UnitModel unitModel)
        {
            if (id != unitModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitModelExists(unitModel.Id))
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

            return View(unitModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitModel = await _context.Units
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitModel == null)
            {
                return NotFound();
            }

            return View(unitModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitModel = await _context.Units.FindAsync(id);

            _context.Units.Remove(unitModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool UnitModelExists(int id)
        {
            return _context.Units.Any(e => e.Id == id);
        }
    }
}
