using ContactBook.Core.Implementations;
using ContactBook.Core.Interfaces;
using ContactBook.Data.DTO;
using ContactBook.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ContactBook.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IImageService _imageService;

        public UserController(IServiceProvider service)
        {
            _userManager = service.GetRequiredService<UserManager<User>>();
            _userService = service.GetRequiredService<IUserService>();
            _imageService = service.GetRequiredService<IImageService>();
        }

        [HttpGet("all-users/{pageNumber}")]
        public async Task<IActionResult> GetAllUsers(int pageNumber)
        {
            var result = await _userService.GetUsers(pageNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("search/{searchWord}/{pageNumber}")]
        public async Task<IActionResult> Search(string searchWord, int pageNumber)
        {
            var result = await _userService.GetUserBySearchWord(searchWord, pageNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetUser(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("get-user/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDTO model)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userService.UpdateUser(user, model);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin, Regular")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userService.DeleteUserByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPatch("photo/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadImage([FromForm] AddImageDTO imageDto, string userId)
        {
            try
            {
                var response = "";
                var upload = await _imageService.UploadImage(imageDto.Image);
                var imageProperties = new ImageAddedDTO()
                {
                    PublicId = upload.PublicId,
                    Url = upload.Url.ToString()
                };

                string url = imageProperties.Url.ToString();
                var result = await _userService.UploadImage(userId, url);


                if (result)
                {
                    response = "Photo updated successfully";
                }
                return Ok(response);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-new-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(RegistrationRequestDTO model)
        {

            try
            {
                var result = await _userService.CreateAsync(model);
                return Created("", result);
            }
            catch (MissingFieldException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
