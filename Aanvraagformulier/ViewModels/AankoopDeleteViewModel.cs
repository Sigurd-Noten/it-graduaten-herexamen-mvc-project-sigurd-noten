namespace Aanvraagformulier.ViewModels
{
    public class AankoopDeleteViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; } = default!;
        public string Beschrijving { get; set; } = default!;
        public DateTime Datum { get; set; }
        public decimal Prijs { get; set; }
        public bool IsApproved { get; set; }
    }
}
