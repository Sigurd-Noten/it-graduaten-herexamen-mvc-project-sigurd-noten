using Aanvraagformulier.Models;
using System.Collections.Generic;

namespace Aanvraagformulier.ViewModels
{
    public class ArchiefListViewModel
    {
        public List<Aankoop> Aankopen { get; set; } = new List<Aankoop>();

        public Dictionary<int, string> AankoopStatus { get; set; } = new Dictionary<int, string>();
    }
}

