using Microsoft.AspNetCore.Identity;
using Aanvraagformulier.Models;

namespace Aanvraagformulier.ViewModels
{
    public class GebruikerListViewModel
    {

        public List<CustomUser> CustomUsers { get; set; }

        public List<IdentityRole> Rollen { get; set; }

        public Dictionary<string, List<string>> UserRoles { get; set; }

    }
}
