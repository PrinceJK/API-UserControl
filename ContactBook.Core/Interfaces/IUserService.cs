using ContactBook.Data.Abstraction;
using ContactBook.Data.DTO;
using ContactBook.Model;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactBook.Core.Interfaces
{
    public interface IUserService
    {
        Task<ICollection<User>> GetUsers(int page);
        Task<Response<Pagination<UserDTO>>> GetUsersByEmail(string email, int page);
        Task<Response<Pagination<UserDTO>>> GetUsersByName(string name, int page);
        Task<IEnumerable<UserDTO>> GetUserBySearchWord(string searchWord, int page);
        int perPage { get; }
        //Task<bool> DeleteUser(string userId);
        //Task<IEnumerable<UserResponseDTO>> GetAllUsers(Pagination pagingParameter);
        //Task<UserResponseDTO> GetUser(string userId);
        //Task<IEnumerable<UserResponseDTO>> Search(Pagination pagingParameter, string searchWord = "");
        //Task<UserResponseDTO> GetUserByEmail(string email);
        //Task<bool> Update(string userId, UpdateUserRequestDTO updateUser);
        //Task<bool> UploadImage(string userId, string url);
        //Task <IdentityResult> CreateAsync(string firstName, string lastName, string email, string userName, string phoneNumber);
    }
}
