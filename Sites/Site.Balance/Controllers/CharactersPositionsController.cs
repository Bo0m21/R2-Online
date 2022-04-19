using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Models;
using Database.Balance.Interfaces;

namespace Site.Balance.Controllers
{
    public class CharactersPositionsController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public CharactersPositionsController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CharacterPositions.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterPositionModel = await _context.CharacterPositions
                .FirstOrDefaultAsync(m => m.Id == id);

            if (characterPositionModel == null)
            {
                return NotFound();
            }

            return View(characterPositionModel);
        }

        public IActionResult Create()
        {
            return View(new CharacterPositionModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CharacterPositionModel characterPositionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characterPositionModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(characterPositionModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterPositionModel = await _context.CharacterPositions.FindAsync(id);

            if (characterPositionModel == null)
            {
                return NotFound();
            }

            return View(characterPositionModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CharacterPositionModel characterPositionModel)
        {
            if (id != characterPositionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterPositionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterPositionModelExists(characterPositionModel.Id))
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

            return View(characterPositionModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterPositionModel = await _context.CharacterPositions.FirstOrDefaultAsync(m => m.Id == id);

            if (characterPositionModel == null)
            {
                return NotFound();
            }

            return View(characterPositionModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterPositionModel = await _context.CharacterPositions.FindAsync(id);

            _context.CharacterPositions.Remove(characterPositionModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CharacterPositionModelExists(int id)
        {
            return _context.CharacterPositions.Any(e => e.Id == id);
        }
    }
}
