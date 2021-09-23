using ContactBook.Core.Interfaces;
using ContactBook.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ContactBook.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthenticationController(IServiceProvider service)
        {
            _authentication = service.GetRequiredService<IAuthentication>();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userRequest)
        {
            try
            {
                return Ok(await _authentication.Login(userRequest));
            }
            catch (AccessViolationException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationRequestDTO registrationRequest)
        {
            try
            {
                var result = await _authentication.Register(registrationRequest);
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
