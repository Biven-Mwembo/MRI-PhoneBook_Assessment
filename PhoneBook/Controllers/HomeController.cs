using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;
using PhoneBook.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        //Connect to the Database
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Retrieve all contacts from the database
            var contacts = _context.contacts.ToList();

            // instance of the ViewModel to pass the contacts list
            var viewModel = new ContactViewModels
            {
                Users = contacts
            };

            // Passing the ViewModel to the view
            return View(viewModel);
        }

         //**Add Contact**
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Contacts contact)
        {
            // Check if a contact with the same Phone Number  already exists to avoid duplicates
            if (await _context.contacts.AnyAsync(c => c.PhoneNumber == contact.PhoneNumber))
            {
                TempData["Alert"] = "A Contact with this Phone Number already exists.";
                TempData["AlertType"] = "danger";
                return View(contact);
            }
            // Check if Phone Number is Longer than 15
            if (contact.PhoneNumber.Length > 15)
            {
                TempData["Alert"] = "A Contact with this Phone Number already exists.";
                TempData["AlertType"] = "danger";
            }


            // Check if Email input is empty and email doesn't have @
            if (!string.IsNullOrEmpty(contact.EmailAddress) && !contact.EmailAddress.Contains('@'))
            {
                TempData["Alert"] = "A Contact with this Phone Number already exists.";
                TempData["AlertType"] = "danger";
                return View(contact);
            }

            // Save Contact Details
            _context.contacts.Add(contact);
            await _context.SaveChangesAsync();
            TempData["Alert"] = contact.Name+ " added successfully!";
            TempData["AlertType"] = "success";  
            // Redirect to the next page
            return RedirectToAction("Index"); //
        }

        //     **Update Contact**  
        //- Allow users to update existing contact details.
        // GET: Edit/Contact
        public async Task<IActionResult> UpdateContact(int id)
        {
            var contact = await _context.contacts.FindAsync(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        // POST: Edit/Contact
        [HttpPost]
        public async Task<IActionResult> UpdateContact(Contacts contact)
        {
            var existingContact = await _context.contacts.FindAsync(contact.Id);
            if (existingContact == null) return NotFound();

            existingContact.Name = contact.Name;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.EmailAddress = contact.EmailAddress;
            TempData["Alert"] = contact.Name + " Updated successfully!";
            TempData["AlertType"] = "success";
            _context.contacts.Update(existingContact);
            await _context.SaveChangesAsync();

           
            return RedirectToAction("Index");
        }


     


   //     **Delete Contact**  
   //- Allow users to delete a contact from the phonebook.
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _context.contacts.FindAsync(id);
            if (contact == null) return NotFound();

            // Move the contact to the DeletedContacts table
            var deletedContact = new DeletedContact
            {
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                EmailAddress = contact.EmailAddress,
                DeletedAt = DateTime.Now
            };

            _context.DeletedContact.Add(deletedContact);
            _context.contacts.Remove(contact);
            await _context.SaveChangesAsync();

            TempData["Alert"] = "Contact successfully moved to Deleted Contacts!";
            return RedirectToAction("Index");
        }



   //     **Search Contact**  
   //- Provide a search functionality to look up contacts by name or phone number.
        public async Task<IActionResult> SearchContacts(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                var allContacts = await _context.contacts.ToListAsync();
                return PartialView("ContactTable", allContacts);
            }

            var filteredContacts = await _context.contacts
                .Where(c => c.Name.Contains(searchTerm) || c.PhoneNumber.Contains(searchTerm))
                .ToListAsync();

            return PartialView("ContactTable", filteredContacts);
        }


        //Extra method to show all the deleted Contatcs
        public async Task<IActionResult> Deleted()
        {
            var deletedContacts = await _context.DeletedContact.ToListAsync();
            return View(deletedContacts);
        }



        //Extra method to restore all the deleted Contatcs
        public async Task<IActionResult> Restore(int id)
        {
            // Find the deleted contact in the DeletedContacts table
            var deletedContact = await _context.DeletedContact.FindAsync(id);
            if (deletedContact == null) return NotFound();

            // Create a new contact and copy the details from the deleted contact
            var restoredContact = new Contacts
            {
                _code = deletedContact._code,
                Name = deletedContact.Name,
                PhoneNumber = deletedContact.PhoneNumber,
                EmailAddress = deletedContact.EmailAddress
            };

            // Add the restored contact back to the Contacts table
            _context.contacts.Add(restoredContact);

            // Remove the contact from the DeletedContacts table
            _context.DeletedContact.Remove(deletedContact);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            TempData["Alert"] = "Contact successfully restored!";
            TempData["AlertType"] = "success";

            // Redirect to the Deleted Contacts page
            return RedirectToAction("Deleted");
        }



        // New method to sort contacts from A-Z
        public async Task<IActionResult> SortContacts()
        {
            // Get the sorted list of contacts
            var sortedContacts = await _context.contacts
                .OrderBy(c => c.Name)
                .ToListAsync();

            // Populate the ContactViewModels
            var viewModel = new ContactViewModels
            {
                Users = sortedContacts
            };

            // Return the Index view with the ViewModel
            return View("Index", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}