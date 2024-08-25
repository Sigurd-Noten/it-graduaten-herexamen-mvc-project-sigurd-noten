namespace Aanvraagformulier.Models
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Initialen { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }
        public bool Verwijderd { get; set; }
        public IList<Aankoop>? Aankopen { get; set; }
    }
}
