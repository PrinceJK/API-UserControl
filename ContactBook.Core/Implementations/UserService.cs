using ContactBook.Core.Interfaces;
using ContactBook.Data.DTO;
using ContactBook.Data.DTO.Mappings;
using ContactBook.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Core.Implementations
{
    public class UserService : IUserService
    {
        public Task<Response<string>> DeleteUserByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserDTO>> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetUserBySearchWord(string searchWord, int page)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetUsers(int page)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Pagination<UserDTO>>> GetUsersByEmail(string email, int page)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Pagination<UserDTO>>> GetUsersByName(string name, int page)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> UpdateUser(User user, UpdateUserDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
