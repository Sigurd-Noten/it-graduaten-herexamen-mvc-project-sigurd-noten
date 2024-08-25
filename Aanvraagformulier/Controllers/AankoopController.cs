using Aanvraagformulier.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aanvraagformulier.Models;
using System.Linq;
using System.Threading.Tasks;
using Aanvraagformulier.ViewModels;

namespace Aanvraagformulier.Controllers
{
    public class AankoopController : Controller
    {
        private readonly AankoopFormulierContext _context;

        public AankoopController(AankoopFormulierContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var aankopen = _context.Aankopen
                .Include(a => a.Gebruiker) 
                .Include(a => a.Vak) 
                .ToList();
            return View(aankopen);
        }

        public IActionResult Create()
        {
            var viewModel = new AankoopCreateViewModel
            {
                Vakken = _context.Vakken.ToList(),
                Gebruikers = _context.Gebruikers.ToList() // Voeg gebruikers toe aan de ViewModel
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder,Coördinator")]
        public async Task<IActionResult> Create(AankoopCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var aankoop = new Aankoop
                {
                    NaamAanvragerId = viewModel.GebruikerId, // Gebruik de ID van de gebruiker
                    Reden = viewModel.Reden,
                    VakId = viewModel.VakId,
                    Datum = viewModel.Datum,
                    Goedgekeurd = viewModel.Goedgekeurd,
                    Verwijderd = false
                };

                _context.Aankopen.Add(aankoop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.Vakken = _context.Vakken.ToList();
            viewModel.Gebruikers = _context.Gebruikers.ToList();
            return View(viewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aankoop = _context.Aankopen
                .Include(a => a.Vak)
                .Include(a => a.Gebruiker) // Inclusief gebruiker
                .FirstOrDefault(a => a.Id == id);

            if (aankoop == null)
            {
                return NotFound();
            }

            var viewModel = new AankoopEditViewModel
            {
                Id = aankoop.Id,
                NaamAanvragerId = aankoop.NaamAanvragerId,
                Reden = aankoop.Reden,
                VakId = aankoop.VakId,
                Datum = aankoop.Datum,
                Goedgekeurd = aankoop.Goedgekeurd,
                Vakken = _context.Vakken.ToList(),
                Gebruikers = _context.Gebruikers.ToList() // Voeg gebruikers toe aan de ViewModel
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder,Coördinator")]
        public async Task<IActionResult> Edit(int id, AankoopEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var aankoop = _context.Aankopen.Find(id);

                if (aankoop == null)
                {
                    return NotFound();
                }

                aankoop.NaamAanvragerId = viewModel.NaamAanvragerId;
                aankoop.Reden = viewModel.Reden;
                aankoop.VakId = viewModel.VakId;
                aankoop.Datum = viewModel.Datum;
                aankoop.Goedgekeurd = viewModel.Goedgekeurd;

                _context.Aankopen.Update(aankoop);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            viewModel.Vakken = _context.Vakken.ToList();
            viewModel.Gebruikers = _context.Gebruikers.ToList();
            return View(viewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aankoop = _context.Aankopen
                .Include(a => a.Vak)
                .Include(a => a.Gebruiker) // Inclusief gebruiker
                .FirstOrDefault(a => a.Id == id);

            if (aankoop == null)
            {
                return NotFound();
            }

            return View(aankoop);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder,Coördinator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aankoop = await _context.Aankopen.FindAsync(id);

            if (aankoop == null)
            {
                return NotFound();
            }

            _context.Aankopen.Remove(aankoop);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
