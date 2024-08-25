using Aanvraagformulier.Models;
using System.ComponentModel.DataAnnotations;

namespace Aanvraagformulier.ViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Aankoop ID is verplicht.")]
        public int AankoopId { get; set; }

        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Hoeveelheid is verplicht.")]
        public string Hoeveelheid { get; set; }

        [Required(ErrorMessage = "Prijs is verplicht.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Prijs moet groter zijn dan 0.")]
        public decimal Prijs { get; set; }
        public IList<Aankoop>? Aankopen { get; set; }
    }
}
