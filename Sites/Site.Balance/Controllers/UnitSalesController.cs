using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Models;
using Database.Balance.Interfaces;

namespace Site.Balance.Controllers
{
    public class UnitSalesController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public UnitSalesController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var databaseBalanceContext = _context.UnitSales.Include(u => u.Item);
            return View(await databaseBalanceContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitSaleModel = await _context.UnitSales
                .Include(u => u.Item)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitSaleModel == null)
            {
                return NotFound();
            }

            return View(unitSaleModel);
        }

        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name");

            return View(new UnitSaleModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitSaleModel unitSaleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitSaleModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", unitSaleModel.ItemId);

            return View(unitSaleModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitSaleModel = await _context.UnitSales.FindAsync(id);

            if (unitSaleModel == null)
            {
                return NotFound();
            }

            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", unitSaleModel.ItemId);

            return View(unitSaleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UnitSaleModel unitSaleModel)
        {
            if (id != unitSaleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitSaleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitSaleModelExists(unitSaleModel.Id))
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

            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", unitSaleModel.ItemId);

            return View(unitSaleModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitSaleModel = await _context.UnitSales
                .Include(u => u.Item)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitSaleModel == null)
            {
                return NotFound();
            }

            return View(unitSaleModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitSaleModel = await _context.UnitSales.FindAsync(id);

            _context.UnitSales.Remove(unitSaleModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool UnitSaleModelExists(int id)
        {
            return _context.UnitSales.Any(e => e.Id == id);
        }
    }
}
