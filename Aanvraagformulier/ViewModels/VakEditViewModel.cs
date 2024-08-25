using System.ComponentModel.DataAnnotations;

namespace Aanvraagformulier.ViewModels
{
    public class EditVakViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        public bool Verwijderd { get; set; }
    }
}
