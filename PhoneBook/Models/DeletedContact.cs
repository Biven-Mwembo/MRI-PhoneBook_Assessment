namespace PhoneBook.Models
{
    public class DeletedContact
    {
        public string _code { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DeletedAt { get; set; } // Track when the contact was deleted
    }

}
