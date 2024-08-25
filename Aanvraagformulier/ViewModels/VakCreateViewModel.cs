using System.ComponentModel.DataAnnotations;

namespace Aanvraagformulier.ViewModels
{
    public class VakCreateViewModel
    {
        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        public bool Verwijderd { get; set; } = false; 
    }
}
