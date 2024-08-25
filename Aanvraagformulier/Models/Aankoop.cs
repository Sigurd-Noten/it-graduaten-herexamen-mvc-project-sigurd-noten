namespace Aanvraagformulier.Models
{
    public class Aankoop
    {
        public int Id { get; set; }
        public int NaamAanvragerId { get; set; }
        public string Reden { get; set; }
        public int VakId { get; set; }
        public DateTime Datum { get; set; }
        public bool Goedgekeurd { get; set; }
        public bool Verwijderd { get; set; }

        public Gebruiker? Gebruiker { get; set; }
        public Vak? Vak { get; set; }
        public IList<Product>? Producten { get; set; }
        public IList<Bijlage>? Bijlagen { get; set; }
    }
}
