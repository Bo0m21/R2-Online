using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Models;
using Database.Balance.Interfaces;

namespace Site.Balance.Controllers
{
    public class ItemReinforcesController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public ItemReinforcesController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var databaseBalanceContext = _context.ItemReinforces.Include(i => i.Item).Include(i => i.Item1).Include(i => i.Item2).Include(i => i.Item3);
            return View(await databaseBalanceContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemReinforceModel = await _context.ItemReinforces
                .Include(i => i.Item)
                .Include(i => i.Item1)
                .Include(i => i.Item2)
                .Include(i => i.Item3)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (itemReinforceModel == null)
            {
                return NotFound();
            }

            return View(itemReinforceModel);
        }

        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name");
            ViewData["ItemOldId"] = new SelectList(_context.Items, "Id", "Name");
            ViewData["ItemNewId"] = new SelectList(_context.Items, "Id", "Name");
            ViewData["Item1Id"] = new SelectList(_context.Items, "Id", "Name");
            ViewData["Item2Id"] = new SelectList(_context.Items, "Id", "Name");
            ViewData["Item3Id"] = new SelectList(_context.Items, "Id", "Name");

            return View(new ItemReinforceModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemReinforceModel itemReinforceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemReinforceModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.ItemId);
            ViewData["ItemOldId"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.ItemOldId);
            ViewData["ItemNewId"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.ItemNewId);
            ViewData["Item1Id"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.Item1Id);
            ViewData["Item2Id"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.Item2Id);
            ViewData["Item3Id"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.Item3Id);

            return View(itemReinforceModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemReinforceModel = await _context.ItemReinforces.FindAsync(id);

            if (itemReinforceModel == null)
            {
                return NotFound();
            }

            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.ItemId);
            ViewData["ItemOldId"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.ItemOldId);
            ViewData["ItemNewId"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.ItemNewId);
            ViewData["Item1Id"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.Item1Id);
            ViewData["Item2Id"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.Item2Id);
            ViewData["Item3Id"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.Item3Id);

            return View(itemReinforceModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ItemReinforceModel itemReinforceModel)
        {
            if (id != itemReinforceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemReinforceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemReinforceModelExists(itemReinforceModel.Id))
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

            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.ItemId);
            ViewData["ItemOldId"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.ItemOldId);
            ViewData["ItemNewId"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.ItemNewId);
            ViewData["Item1Id"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.Item1Id);
            ViewData["Item2Id"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.Item2Id);
            ViewData["Item3Id"] = new SelectList(_context.Items, "Id", "Name", itemReinforceModel.Item3Id);

            return View(itemReinforceModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemReinforceModel = await _context.ItemReinforces
                .Include(i => i.Item)
                .Include(i => i.Item1)
                .Include(i => i.Item2)
                .Include(i => i.Item3)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (itemReinforceModel == null)
            {
                return NotFound();
            }

            return View(itemReinforceModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemReinforceModel = await _context.ItemReinforces.FindAsync(id);

            _context.ItemReinforces.Remove(itemReinforceModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ItemReinforceModelExists(int id)
        {
            return _context.ItemReinforces.Any(e => e.Id == id);
        }
    }
}
