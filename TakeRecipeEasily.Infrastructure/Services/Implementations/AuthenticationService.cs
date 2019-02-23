using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Exceptions.ErrorMessages;
using TakeRecipeEasily.Infrastructure.SQL;
using TakeRecipeEasily.Infrastructure.Validation;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(
            DatabaseContext dbContext,
            IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await GetUserAsync(email)
                .ThrowIfNullAsync(ErrorType.NotFound, UsersErrorCodes.InvalidCredentials);

            _passwordHasher
                .VerifyPassword(user.HashedPassword, password)
                .ThrowIfFalse(ErrorType.NotFound, UsersErrorCodes.InvalidCredentials);
        }

        private async Task<User> GetUserAsync(string email)
            => await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
