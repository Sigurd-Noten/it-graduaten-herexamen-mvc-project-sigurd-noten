namespace Aanvraagformulier.ViewModels
{
    public class GebruikerDeleteViewModel
    {
        public string Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsDeleted { get; set; }
    }
}
