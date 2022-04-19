using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database.Balance.Models;
using Database.Balance.Interfaces;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Enums;

namespace Site.Balance.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public ItemsController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        [Route("Items")]
        public async Task<IActionResult> Index(ItemTypeEnum itemType)
        {
            if (itemType == ItemTypeEnum.All)
            {
                return View(await _context.Items.OrderBy(i => i.ItemId).ToListAsync());
            }
            if (itemType == ItemTypeEnum.AllEquip)
            {
                return View(await _context.Items.Where(i => i.EquipType != null).OrderBy(i => i.ItemId).ToListAsync());
            }
            if (itemType == ItemTypeEnum.AllUsable)
            {
                return View(await _context.Items.Where(i => i.IsUsable == true).OrderBy(i => i.ItemId).ToListAsync());
            }


            ViewData["type"] = itemType;

            return View(await _context.Items.Where(i => i.Type == itemType).OrderBy(i => i.ItemId).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items
                .Include(m => m.UnitDrops)
                    .ThenInclude(m => m.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        public IActionResult Create(ItemTypeEnum itemType)
        {
            return View(new ItemModel() { Type = itemType});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemModel itemEquipModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemEquipModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { itemType = itemEquipModel.Type.ToString() });
            }

            return View(itemEquipModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemEquipModel = await _context.Items.FindAsync(id);

            if (itemEquipModel == null)
            {
                return NotFound();
            }

            return View(itemEquipModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ItemModel itemEquipModel)
        {
            if (id != itemEquipModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemEquipModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemEquipModelExists(itemEquipModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index), new { itemType = itemEquipModel.Type.ToString() });
            }

            return View(itemEquipModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemEquipModel = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);

            if (itemEquipModel == null)
            {
                return NotFound();
            }

            return View(itemEquipModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemModel = await _context.Items.FindAsync(id);

            _context.Items.Remove(itemModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { itemType = itemModel.Type.ToString() });
        }

        private bool ItemEquipModelExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
