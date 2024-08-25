using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aanvraagformulier.Data;
using Aanvraagformulier.Models;
using Aanvraagformulier.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Aanvraagformulier.Controllers
{
    public class ProductController : Controller
    {
        private readonly AankoopFormulierContext _context;

        public ProductController(AankoopFormulierContext context)
        {
            _context = context;
        }

        // GET: Product
        public IActionResult Index()
        {
            var producten = _context.Producten
                .Include(p => p.Aankoop) // Inclusief aankoop voor detailweergave
                .ToList();
            return View(producten);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            var viewModel = new CreateProductViewModel
            {
                Aankopen = _context.Aankopen.ToList() // Verkrijg alle aankopen voor de keuzelijst
            };
            return View(viewModel);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder,Coördinator")]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    AankoopId = viewModel.AankoopId,
                    Naam = viewModel.Naam,
                    Hoeveelheid = viewModel.Hoeveelheid,
                    Prijs = viewModel.Prijs
                };

                _context.Producten.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.Aankopen = _context.Aankopen.ToList();
            return View(viewModel);
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Producten
                .Include(p => p.Aankoop) // Inclusief aankoop voor detailweergave
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new EditProductViewModel
            {
                Id = product.Id,
                Naam = product.Naam,
                Hoeveelheid = product.Hoeveelheid,
                Prijs = product.Prijs,
                AankoopId = product.AankoopId,
                Aankopen = _context.Aankopen.ToList() // Verkrijg alle aankopen voor de keuzelijst
            };

            return View(viewModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder,Coördinator")]
        public async Task<IActionResult> Edit(int id, EditProductViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var product = _context.Producten.Find(id);

                if (product == null)
                {
                    return NotFound();
                }

                product.Naam = viewModel.Naam;
                product.Hoeveelheid = viewModel.Hoeveelheid;
                product.Prijs = viewModel.Prijs;
                product.AankoopId = viewModel.AankoopId;

                _context.Producten.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            viewModel.Aankopen = _context.Aankopen.ToList();
            return View(viewModel);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Producten
                .Include(p => p.Aankoop) // Inclusief aankoop voor detailweergave
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Beheerder,Coördinator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Producten.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Producten.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
