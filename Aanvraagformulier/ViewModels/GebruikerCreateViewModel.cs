using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Identity;

namespace Aanvraagformulier.ViewModels
{
    public class GebruikerCreateViewModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht.")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Initialen zijn verplicht.")]
        public string Initialen { get; set; }

        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Rol is verplicht.")]
        public string SelectedRole { get; set; }

        public bool IsDeleted { get; set; }
    }
}

