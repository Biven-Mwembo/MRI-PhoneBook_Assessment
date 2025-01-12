using PhoneBook.Models;
using Microsoft.EntityFrameworkCore;


namespace PhoneBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Contacts> contacts { get; set; }
        public DbSet<DeletedContact> DeletedContact { get; set; }






    }
}
