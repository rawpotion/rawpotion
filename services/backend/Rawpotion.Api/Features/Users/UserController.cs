using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rawpotion.Api.Error;
using Rawpotion.Api.Models;
using static BCrypt.Net.BCrypt;

namespace Rawpotion.Api.Features.Users
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserAdd userRequest)
        {
            var createUser = userRequest.AdaptToUser();

            var existingUserResult = await _userRepository.GetUserByEmailAsync(userRequest.Email);
            if (existingUserResult.IsSuccess)
                return NotFound(new NotFoundError("user was found already, aborting"));
            
            createUser.PasswordHash = EnhancedHashPassword(userRequest.Password);
            var userResults = await _userRepository.CreateUserAsync(createUser);
            if (userResults.IsFailed)
                return StatusCode(500, new InternalServerError(userResults.Errors));

            return Ok(userResults
                .Value
                .AdaptToDto());
        }
    }
}