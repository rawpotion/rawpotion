using System.Threading.Tasks;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Rawpotion.Api.Database;
using Rawpotion.Api.Domain;
using static FluentResults.Results;

namespace Rawpotion.Api.Features.Users
{
    public interface IUserRepository
    {
        Task<Result<User>> CreateUserAsync(User createUser);
        Task<Result<User>> GetUserByEmailAsync(string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<User>> CreateUserAsync(User createUser) =>
            await Result.Try(async () =>
            {
                var user = _context.Users.Add(createUser);
       
                await _context.SaveChangesAsync();

                return user.Entity;
            });
        
        public async Task<Result<User>> GetUserByEmailAsync(string email) =>
            Ok(await _context
                .Users
                .FirstOrDefaultAsync(u =>
                    u.Email == email));
    }
}