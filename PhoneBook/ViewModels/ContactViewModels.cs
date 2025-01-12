using PhoneBook.Models;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.ViewModels
{
    public class ContactViewModels
    {
        public List<PhoneBook.Models.Contacts> Users { get; set; }
    }
}
