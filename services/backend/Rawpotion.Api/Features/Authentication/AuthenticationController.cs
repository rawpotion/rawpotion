using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rawpotion.Api.Error;
using Rawpotion.Api.Features.Users;

namespace Rawpotion.Api.Features.Authentication
{
    public record Login(string Email, string Password);

    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email).NotEmpty().EmailAddress();
            RuleFor(l => l.Password).NotEmpty();
        }
    }
    
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
           var userResult = await _userRepository.GetUserByEmailAsync(login.Email);
           if (userResult.IsFailed)
               return NotFound(new NotFoundError("User doesn't exist with that email"));

           if (!BCrypt.Net.BCrypt.EnhancedVerify(login.Password, userResult.Value.PasswordHash))
               return BadRequest(new BadRequestError("Passwords didn't match"));

           return Ok();
        }
    }
}