using System.ComponentModel.DataAnnotations;
using Aanvraagformulier.Models;

namespace Aanvraagformulier.ViewModels
{
    public class EditBijlageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Aankoop ID is verplicht.")]
        public int AankoopId { get; set; }

        public List<Aankoop>? Aankopen { get; set; }
    }
}
