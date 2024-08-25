using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aanvraagformulier.Models;

namespace Aanvraagformulier.ViewModels
{
    public class CreateAankoopViewModel
    {
        [Required(ErrorMessage = "Naam aanvrager is verplicht.")]
        public int NaamAanvragerId { get; set; }

        [Required(ErrorMessage = "Datum is verplicht.")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Reden is verplicht.")]
        public string Reden { get; set; }

        [Required(ErrorMessage = "Vak is verplicht.")]
        public int VakId { get; set; }

        public List<Vak>? Vakken { get; set; }
        public List<Gebruiker>? Gebruikers { get; set; }
    }
}
