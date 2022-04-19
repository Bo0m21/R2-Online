using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Models;
using Database.Balance.Interfaces;

namespace Site.Balance.Controllers
{
    public class UnitPurchasesController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public UnitPurchasesController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var databaseBalanceContext = _context.UnitPurchases.Include(u => u.Item).Include(u => u.Unit);
            return View(await databaseBalanceContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitPurchaseModel = await _context.UnitPurchases
                .Include(u => u.Unit)
                .Include(u => u.Item)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitPurchaseModel == null)
            {
                return NotFound();
            }

            return View(unitPurchaseModel);
        }

        public IActionResult Create()
        {
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name");

            return View(new UnitPurchaseModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitPurchaseModel unitPurchaseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitPurchaseModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", unitPurchaseModel.UnitId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", unitPurchaseModel.ItemId);

            return View(unitPurchaseModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitPurchaseModel = await _context.UnitPurchases.FindAsync(id);

            if (unitPurchaseModel == null)
            {
                return NotFound();
            }

            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", unitPurchaseModel.UnitId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", unitPurchaseModel.ItemId);

            return View(unitPurchaseModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UnitPurchaseModel unitPurchaseModel)
        {
            if (id != unitPurchaseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitPurchaseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitPurchaseModelExists(unitPurchaseModel.Id))
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

            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", unitPurchaseModel.UnitId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", unitPurchaseModel.ItemId);
            
            return View(unitPurchaseModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitPurchaseModel = await _context.UnitPurchases
                .Include(u => u.Unit)
                .Include(u => u.Item)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitPurchaseModel == null)
            {
                return NotFound();
            }

            return View(unitPurchaseModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitPurchaseModel = await _context.UnitPurchases.FindAsync(id);

            _context.UnitPurchases.Remove(unitPurchaseModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool UnitPurchaseModelExists(int id)
        {
            return _context.UnitPurchases.Any(e => e.Id == id);
        }
    }
}
