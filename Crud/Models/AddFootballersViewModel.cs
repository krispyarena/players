namespace Crud.Models
{
    public class AddFootballersViewModel
    {
        public Guid? PlayerId { get; set; }
        public string Name { get; set; }
        public int Goals { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public bool IsSubscribed { get; set; }

    }
}
