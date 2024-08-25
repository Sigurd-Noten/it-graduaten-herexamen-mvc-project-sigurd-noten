using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aanvraagformulier.Data;
using Aanvraagformulier.Models;
using Aanvraagformulier.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Aanvraagformulier.Controllers
{
    public class BijlageController : Controller
    {
        private readonly AankoopFormulierContext _context;

        public BijlageController(AankoopFormulierContext context)
        {
            _context = context;
        }

        // GET: Bijlage
        public IActionResult Index()
        {
            var bijlagen = _context.Bijlagen
                .Include(b => b.Aankoop) // Inclusief aankoop voor detailweergave
                .ToList();
            return View(bijlagen);
        }

        // GET: Bijlage/Create
        public IActionResult Create()
        {
            var viewModel = new BijlageCreateViewModel
            {
                Aankopen = _context.Aankopen.ToList() // Verkrijg alle aankopen voor de keuzelijst
            };
            return View(viewModel);
        }

        // POST: Bijlage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder,Coördinator")]
        public async Task<IActionResult> Create(BijlageCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var bijlage = new Bijlage
                {
                    AankoopId = viewModel.AankoopId,
                    Naam = viewModel.Naam
                };

                _context.Bijlagen.Add(bijlage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.Aankopen = _context.Aankopen.ToList();
            return View(viewModel);
        }

        // GET: Bijlage/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bijlage = _context.Bijlagen
                .Include(b => b.Aankoop) // Inclusief aankoop voor detailweergave
                .FirstOrDefault(b => b.Id == id);

            if (bijlage == null)
            {
                return NotFound();
            }

            var viewModel = new EditBijlageViewModel
            {
                Id = bijlage.Id,
                Naam = bijlage.Naam,
                AankoopId = bijlage.AankoopId,
                Aankopen = _context.Aankopen.ToList() // Verkrijg alle aankopen voor de keuzelijst
            };

            return View(viewModel);
        }

        // POST: Bijlage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder,Coördinator")]
        public async Task<IActionResult> Edit(int id, EditBijlageViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var bijlage = _context.Bijlagen.Find(id);

                if (bijlage == null)
                {
                    return NotFound();
                }

                bijlage.Naam = viewModel.Naam;
                bijlage.AankoopId = viewModel.AankoopId;

                _context.Bijlagen.Update(bijlage);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            viewModel.Aankopen = _context.Aankopen.ToList();
            return View(viewModel);
        }

        // GET: Bijlage/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bijlage = _context.Bijlagen
                .Include(b => b.Aankoop) // Inclusief aankoop voor detailweergave
                .FirstOrDefault(b => b.Id == id);

            if (bijlage == null)
            {
                return NotFound();
            }

            return View(bijlage);
        }

        // POST: Bijlage/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder,Coördinator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bijlage = await _context.Bijlagen.FindAsync(id);

            if (bijlage == null)
            {
                return NotFound();
            }

            _context.Bijlagen.Remove(bijlage);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
