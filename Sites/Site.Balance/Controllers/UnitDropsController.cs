using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Database.Balance.Models;
using Database.Balance.Interfaces;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Enums;

namespace Site.Balance.Controllers
{
    public class UnitDropsController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public UnitDropsController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var databaseBalanceContext = _context.UnitDrops.Include(u => u.Item).Include(u => u.Unit);
            return View(await databaseBalanceContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitEquipDropModel = await _context.UnitDrops
                .Include(u => u.Unit)
                .Include(u => u.Item)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitEquipDropModel == null)
            {
                return NotFound();
            }

            return View(unitEquipDropModel);
        }

        public IActionResult Create()
        {
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name");

            var unitEquipDropModel = new UnitDropModel();
            unitEquipDropModel.ItemStatus = ItemStatusTypeEnum.Normal;
            unitEquipDropModel.ItemBind = ItemBindTypeEnum.None;

            return View(unitEquipDropModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitDropModel unitEquipDropModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitEquipDropModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", unitEquipDropModel.UnitId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", unitEquipDropModel.ItemId);

            return View(unitEquipDropModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitEquipDropModel = await _context.UnitDrops.FindAsync(id);

            if (unitEquipDropModel == null)
            {
                return NotFound();
            }

            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", unitEquipDropModel.UnitId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", unitEquipDropModel.ItemId);
           
            return View(unitEquipDropModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UnitDropModel unitEquipDropModel)
        {
            if (id != unitEquipDropModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitEquipDropModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitDropModelExists(unitEquipDropModel.Id))
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

            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", unitEquipDropModel.UnitId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", unitEquipDropModel.ItemId);
           
            return View(unitEquipDropModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitEquipDropModel = await _context.UnitDrops
                .Include(u => u.Item)
                .Include(u => u.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (unitEquipDropModel == null)
            {
                return NotFound();
            }

            return View(unitEquipDropModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitEquipDropModel = await _context.UnitDrops.FindAsync(id);

            _context.UnitDrops.Remove(unitEquipDropModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool UnitDropModelExists(int id)
        {
            return _context.UnitDrops.Any(e => e.Id == id);
        }
    }
}
