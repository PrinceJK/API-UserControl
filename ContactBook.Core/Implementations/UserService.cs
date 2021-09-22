using ContactBook.Core.Interfaces;
using ContactBook.Data.Abstraction;
using ContactBook.Data.DTO;
using ContactBook.Data.DTO.Mappings;
using ContactBook.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Core.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IImageService _imageService;
        private readonly IUserRepository _userRepository;
        public UserService(IServiceProvider service)
        {
            _imageService = service.GetRequiredService<IImageService>();
            _userManager = service.GetRequiredService<UserManager<User>>();
            _userRepository = service.GetRequiredService<IUserRepository>();
        }
        public async Task<Response<string>> DeleteUserByUserId(string id)
        {
            Response<string> response = new();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                response.Message = "Cannot find user";
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                response.Success = true;
                response.Message = $"User with id {id} deleted";
            }
            else
            {
                response.Message = $"Could not delete user with {id}";
            }
            return response;
        }

        public async Task<Response<UserDTO>> GetUser(string id)
        {
            Response<UserDTO> response = new();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                response.Message = "User not existing";
            }
            var dto = MapToUserDTO.ToUserDTO(user);
            if (dto == null)
            {
                response.Message = "User not found";
            }
            else
            {
                response.Message = "User found";
                response.Success = true;
                response.Data = dto;
            }
            return response;
            
        }

        public async Task<Response<Pagination<UserDTO>>> GetUserBySearchWord(string searchWord, int page)
        {
            Response<Pagination<UserDTO>> response = new();
            var users = await _userRepository.GetUserBySearchWord(searchWord, page);
            if (users == null)
            {
                response.Message = "No user on this page";
            }
            var pagedResult = GetPaginatedUsersDtos(page, users);
            if (pagedResult != null)
            {
                response.Success = true;
                response.Message = "Successful Operation";
                response.Data = pagedResult;
            }
            response.Message = "No user found";
            return response;
        }

        public async Task<Response<Pagination<UserDTO>>> GetUsers(int page)
        {
            Response<Pagination<UserDTO>> response= new();
            var users = await _userRepository.GetUsers(page);
            if (users == null)
            {
                response.Message = "No user on this page";
            }
            var result = GetPaginatedUsersDtos(page, users);
            if (result == null)
            {
                response.Message = "Could not fetch users";
            }
            else
            {
                response.Success = true;
                response.Message = "Operation Successful";
                response.Data = result;
            }
            return response;
        }

        public async Task<Response<Pagination<UserDTO>>> GetUsersByEmail(string email, int page)
        {
            Response<Pagination<UserDTO>> response = new();
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                response.Message = "User found";
                response .Success = true;
            }
            response.Message = "User not found";
            return response;
        }

        public async Task<Response<Pagination<UserDTO>>> GetUsersByName(string name, int page)
        {
            Response<Pagination<UserDTO>> response = new();
            var users = await _userRepository.GetUsersByName(name, page);

            if (users != null)
            {
                response.Message = "no users on this page";
            }

            var pagedResult = GetPaginatedUsersDtos(page, users);

            if (pagedResult != null)
            {
                response.Success = true;
                response.Message = "Operation Successful!";
                response.Data = pagedResult;
            }
            else
            {
                response.Message = "operation not successful";
            }
            return response;
        }

        public async Task<Response<string>> UpdateUser(User user, UpdateUserDTO model)
        {
            Response<string> response = new Response<string>();
            if (user == null)
            {
                response.Message = "Please fill the fields to update your info";
            }
            user.FirstName = model.FirstName ?? user.FirstName;
            user.LastName = model.LastName ?? user.LastName;
            user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                response.Success = true;
                response.Message = "Profile updated successfully!";
            }
            else
            {
                response.Message = "Profile update failed";
            }
            return response;
        }

        private Pagination<UserDTO> GetPaginatedUsersDtos(int pageNumber, ICollection<User> users)
        {

            ICollection<UserDTO> mapUsersToDto = PaginationMappers.ForUsers(users);

            return new Pagination<UserDTO>
            {
                TotalNumberOfItems = _userRepository.TotalNumberOfItems,
                TotalNumberOfPages = _userRepository.TotalNumberOfPages,
                Items = mapUsersToDto,
                ItemsPerPage = _userRepository.perPage,
                CurrentPage = pageNumber
            };
        }
    }
}
