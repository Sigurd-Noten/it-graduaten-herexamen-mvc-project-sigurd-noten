namespace Aanvraagformulier.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int AankoopId { get; set; }
        public string Naam { get; set; }
        public string Hoeveelheid { get; set; }
        public decimal Prijs { get; set; }
        public Aankoop? Aankoop { get; set; }
    }
}

