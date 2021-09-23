using ContactBook.Core.Interfaces;
using ContactBook.Data.DTO;
using ContactBook.Data.DTO.Mappings;
using ContactBook.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Core.Implementations
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IConfiguration _configuration;

        public Authentication(IServiceProvider service)
        {
            _userManager = service.GetRequiredService<UserManager<User>>();
            _tokenGenerator = service.GetRequiredService<ITokenGenerator>();
            _configuration = service.GetRequiredService<IConfiguration>();
        }

        public async Task<UserResponseDTO> Login(UserLoginDTO userLogin)
        {
            User user = await _userManager.FindByEmailAsync(userLogin.Email);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userLogin.Password))
                {
                    var response = MapToUserDTO.ToUserResponseDTO(user);
                    response.Token = await _tokenGenerator.GenerateToken(user, _configuration);
                    return response;
                }

                throw new AccessViolationException("Invalid Credentials");
            }
            throw new AccessViolationException("Invalid Credentials");
        }

        public async Task<UserResponseDTO> Register(RegistrationRequestDTO registrationRequest)
        {
            User user = MapToUserDTO.ToUserRegistrationDTO(registrationRequest);
            IdentityResult result = await _userManager.CreateAsync(user, registrationRequest.PassWord);
            if (result.Succeeded)
            {
                return MapToUserDTO.ToUserResponseDTO(user);
            }

            string errors = string.Empty;

            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }

            throw new MissingFieldException(errors);
        }
    }
}
