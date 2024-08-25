using System.Collections.Generic;
using Aanvraagformulier.Models;

namespace Aanvraagformulier.ViewModels
{
    public class AankoopListViewModel
    {
        public List<Aankoop> Aankopen { get; set; }
        public List<Gebruiker> Gebruikers { get; set; }
        public List<Vak> Vakken { get; set; }
    }
}
