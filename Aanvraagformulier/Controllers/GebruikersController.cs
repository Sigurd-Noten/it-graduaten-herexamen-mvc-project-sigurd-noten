using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aanvraagformulier.Data;
using Aanvraagformulier.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Aanvraagformulier.Controllers
{
    [Authorize(Roles = "Beheerder")]
    public class GebruikerController : Controller
    {
        private readonly AankoopFormulierContext _context;

        public GebruikerController(AankoopFormulierContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var gebruikers = _context.Gebruikers.Where(g => !g.Verwijderd).ToList();
            return View(gebruikers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                gebruiker.Verwijderd = false;
                _context.Gebruikers.Add(gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gebruiker);
        }

        public IActionResult Edit(int id)
        {
            var gebruiker = _context.Gebruikers.Find(id);

            if (gebruiker == null)
            {
                return NotFound();
            }

            return View(gebruiker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Gebruiker gebruiker)
        {
            if (id != gebruiker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Gebruikers.Update(gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gebruiker);
        }

        public IActionResult Inactive(int id)
        {
            var gebruiker = _context.Gebruikers.Find(id);

            if (gebruiker == null)
            {
                return NotFound();
            }

            gebruiker.Verwijderd = true;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
