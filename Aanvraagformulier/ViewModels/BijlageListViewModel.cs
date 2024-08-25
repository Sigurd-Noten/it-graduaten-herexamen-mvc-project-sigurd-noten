using System.Collections.Generic;
using Aanvraagformulier.Models;

namespace Aanvraagformulier.ViewModels
{
    public class BijlageListViewModel
    {
        public List<Bijlage> Bijlagen { get; set; }
        public List<Aankoop> Aankopen { get; set; }
    }
}
