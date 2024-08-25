using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aanvraagformulier.Models;

namespace Aanvraagformulier.ViewModels
{
    public class CreateBijlageViewModel
    {
        [Required(ErrorMessage = "Aankoop ID is verplicht.")]
        public int AankoopId { get; set; }

        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        public List<Aankoop>? Aankopen { get; set; }
    }
}
