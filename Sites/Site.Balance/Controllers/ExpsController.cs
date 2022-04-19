using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Models;
using Database.Balance.Interfaces;

namespace Site.Balance.Controllers
{
    public class ExpsController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public ExpsController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Exp.ToListAsync());
        }

        public async Task<IActionResult> Details(int? level)
        {
            if (level == null)
            {
                return NotFound();
            }

            var expModel = await _context.Exp
                .FirstOrDefaultAsync(m => m.Level == level);

            if (expModel == null)
            {
                return NotFound();
            }

            return View(expModel);
        }

        public IActionResult Create()
        {
            return View(new ExpModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpModel expModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(expModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expModel = await _context.Exp.FindAsync(id);

            if (expModel == null)
            {
                return NotFound();
            }

            return View(expModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int level, ExpModel expModel)
        {
            if (level != expModel.Level)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpModelExists(expModel.Level))
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

            return View(expModel);
        }

        public async Task<IActionResult> Delete(int? level)
        {
            if (level == null)
            {
                return NotFound();
            }

            var expModel = await _context.Exp.FirstOrDefaultAsync(m => m.Level == level);

            if (expModel == null)
            {
                return NotFound();
            }

            return View(expModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int level)
        {
            var expModel = await _context.Exp.FirstOrDefaultAsync(m => m.Level == level);

            _context.Exp.Remove(expModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ExpModelExists(int level)
        {
            return _context.Exp.Any(e => e.Level == level);
        }
    }
}
