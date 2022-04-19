using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Models;
using Database.Balance.Interfaces;

namespace Site.Balance.Controllers
{
    public class BuffItemsController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public BuffItemsController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var databaseBalanceContext = _context.BuffItems.Include(b => b.Buff).Include(b => b.Item);
            return View(await databaseBalanceContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffItemModel = await _context.BuffItems
                .Include(b => b.Buff)
                .Include(b => b.Item)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (buffItemModel == null)
            {
                return NotFound();
            }

            return View(buffItemModel);
        }

        public IActionResult Create()
        {
            ViewData["BuffId"] = new SelectList(_context.Buffs, "Id", "Name");
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name");

            return View(new BuffItemModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuffItemModel buffItemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buffItemModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["BuffId"] = new SelectList(_context.Buffs, "Id", "Name", buffItemModel.BuffId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", buffItemModel.ItemId);

            return View(buffItemModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffItemModel = await _context.BuffItems.FindAsync(id);

            if (buffItemModel == null)
            {
                return NotFound();
            }

            ViewData["BuffId"] = new SelectList(_context.Buffs, "Id", "Name", buffItemModel.BuffId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", buffItemModel.ItemId);

            return View(buffItemModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BuffItemModel buffItemModel)
        {
            if (id != buffItemModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buffItemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuffItemModelExists(buffItemModel.Id))
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

            ViewData["BuffId"] = new SelectList(_context.Buffs, "Id", "Name", buffItemModel.BuffId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", buffItemModel.ItemId);

            return View(buffItemModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffItemModel = await _context.BuffItems
                .Include(b => b.Buff)
                .Include(b => b.Item)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (buffItemModel == null)
            {
                return NotFound();
            }

            return View(buffItemModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buffItemModel = await _context.BuffItems.FindAsync(id);

            _context.BuffItems.Remove(buffItemModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool BuffItemModelExists(int id)
        {
            return _context.BuffItems.Any(e => e.Id == id);
        }
    }
}
