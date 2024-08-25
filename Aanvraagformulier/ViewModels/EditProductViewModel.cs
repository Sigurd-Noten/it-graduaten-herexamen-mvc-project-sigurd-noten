using Aanvraagformulier.Models;
using System.Collections.Generic;

namespace Aanvraagformulier.ViewModels
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Hoeveelheid { get; set; }
        public decimal Prijs { get; set; }
        public int AankoopId { get; set; }
        public IEnumerable<Aankoop> Aankopen { get; set; }
    }
}
