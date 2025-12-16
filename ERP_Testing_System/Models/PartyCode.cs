namespace ERP_Testing_System.Models
{
    public class Party : BaseEntity
    {
        public string PartyName { get; set; } = "";
        public string ContactPerson { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
