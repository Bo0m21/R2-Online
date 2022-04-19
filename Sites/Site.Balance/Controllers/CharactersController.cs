using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Balance.Models;
using Database.Balance.Interfaces;

namespace Site.Balance.Controllers
{
    public class CharactersController : Controller
    {
        private readonly IDatabaseBalanceContext _context;

        public CharactersController(IDatabaseBalanceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Characters.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterModel = await _context.Characters
                .FirstOrDefaultAsync(m => m.Id == id);

            if (characterModel == null)
            {
                return NotFound();
            }

            return View(characterModel);
        }

        public IActionResult Create()
        {
            return View(new CharacterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CharacterModel characterModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characterModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(characterModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterModel = await _context.Characters.FindAsync(id);

            if (characterModel == null)
            {
                return NotFound();
            }

            return View(characterModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CharacterModel characterModel)
        {
            if (id != characterModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterModelExists(characterModel.Id))
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

            return View(characterModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterModel = await _context.Characters.FirstOrDefaultAsync(m => m.Id == id);

            if (characterModel == null)
            {
                return NotFound();
            }

            return View(characterModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterModel = await _context.Characters.FindAsync(id);

            _context.Characters.Remove(characterModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CharacterModelExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
