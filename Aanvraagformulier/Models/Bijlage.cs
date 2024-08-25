namespace Aanvraagformulier.Models
{
    public class Bijlage
    {
        public int Id { get; set; }
        public int AankoopId { get; set; }
        public string Naam { get; set; }
        public Aankoop? Aankoop { get; set; }
    }
}
