using Aanvraagformulier.Models;

namespace Aanvraagformulier.ViewModels
{
    public class DeleteBijlageViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int AankoopId { get; set; }

        public Aankoop? Aankoop { get; set; }
    }
}
