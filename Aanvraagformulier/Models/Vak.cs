namespace Aanvraagformulier.Models
{
    public class Vak
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public bool Verwijderd { get; set; }
        public IList<Aankoop>? Aankopen { get; set; }
    }
}
