using System.Collections.Generic;
using Aanvraagformulier.Models;

namespace Aanvraagformulier.ViewModels
{
    public class ProductListViewModel
    {
        public List<Product> Producten { get; set; }
        public List<Aankoop> Aankopen { get; set; }
    }
}
