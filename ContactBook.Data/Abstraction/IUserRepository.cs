using ContactBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Data.Abstraction
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<ICollection<User>> GetUsers(int page);
        Task<ICollection<User>> GetUsersByEmail(string email, int page);
        Task<ICollection<User>> GetUsersByName(string name, int page);
        Task<ICollection<User>> GetUserBySearchWord(string searchWord, int page);
        int perPage { get; }
    }
}
