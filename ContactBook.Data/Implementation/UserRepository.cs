using ContactBook.Data.Abstraction;
using ContactBook.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Data.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ContactBookContext context) : base (context)
        {

        }
        public int perPage { get; } = 10;

        public async Task<IEnumerable<User>> GetUserBySearchWord(string searchWord, int page)
        {
            searchWord = searchWord.ToLower();
            var users = GetAll().Where(u => u.FirstName.ToLower().Contains(searchWord)
            || u.LastName.ToLower().Contains(searchWord)
            || u.FirstName.ToLower() + " " + u.LastName.ToLower() == searchWord).AsNoTracking();
            var pagedUsers = await GetPaginated(page, perPage, users);
            return pagedUsers;
        }

        public async Task<ICollection<User>> GetUsers(int page)
        {
            var users = GetAll();
            var pagedUsers = await GetPaginated(page, perPage, users);
            return pagedUsers;

        }

        public async Task<ICollection<User>> GetUsersByEmail(string email, int page)
        {
            var usersInSquad = GetAll().Where(u => u.Email.ToLower() == email.ToLower()).AsNoTracking();
            var pagedUsers = await GetPaginated(page, perPage, usersInSquad);
            return pagedUsers;
        }

        public async Task<ICollection<User>> GetUsersByName(string name, int page)
        {
            var usersWithName = GetAll().Where(u => u.FirstName.ToLower().StartsWith(name.ToLower())
           || u.LastName.ToLower().StartsWith(name.ToLower())
           || u.FirstName.ToLower() + " " + u.LastName.ToLower() == name.ToLower()).AsNoTracking();

            var pagedUsers = await GetPaginated(page, perPage, usersWithName);
            return pagedUsers;
        }
    }
}
