using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Models;
using Database.Balance.Interfaces;

namespace Site.Balance.Controllers
{
    public class BuffsController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public BuffsController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Buffs.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffModel = await _context.Buffs
                .FirstOrDefaultAsync(m => m.Id == id);

            if (buffModel == null)
            {
                return NotFound();
            }

            return View(buffModel);
        }

        public IActionResult Create()
        {
            return View(new BuffModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuffModel buffModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buffModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(buffModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffModel = await _context.Buffs.FindAsync(id);

            if (buffModel == null)
            {
                return NotFound();
            }

            return View(buffModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BuffModel buffModel)
        {
            if (id != buffModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buffModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuffModelExists(buffModel.Id))
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

            return View(buffModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffModel = await _context.Buffs
                .FirstOrDefaultAsync(m => m.Id == id);

            if (buffModel == null)
            {
                return NotFound();
            }

            return View(buffModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buffModel = await _context.Buffs.FindAsync(id);

            _context.Buffs.Remove(buffModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool BuffModelExists(int id)
        {
            return _context.Buffs.Any(e => e.Id == id);
        }
    }
}
