using ContactBook.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Data
{
    public class ContactBookContext : IdentityDbContext<User>
    {
        public ContactBookContext(DbContextOptions<ContactBookContext> options) : base (options)
        {

        }

    }
}
