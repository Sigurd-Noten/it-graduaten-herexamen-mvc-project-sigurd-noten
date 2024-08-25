using Microsoft.AspNetCore.Identity;

namespace Aanvraagformulier.Models
{
    public class CustomUser : IdentityUser
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public bool Verwijderd { get; set; } = false;

        public IList<Aankoop>? Aankopen { get; set; }

        public IList<Gebruiker>? Gebruiker { get; set; }

        public IList<Product>? Product { get; set; }
        public IList<Bijlage>? Bijlage { get; set; }
        public IList<Vak>? Vak { get; set; }
    }
}
