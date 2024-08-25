using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aanvraagformulier.ViewModels
{
    public class GebruikerEditViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Initialen zijn verplicht.")]
        public string Initials { get; set; }

        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public string SelectedRole { get; set; }
        public List<SelectListItem>? AvailableRoles { get; set; }
    }
}