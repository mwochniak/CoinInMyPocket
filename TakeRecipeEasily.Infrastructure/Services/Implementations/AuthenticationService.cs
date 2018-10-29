using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Infrastructure.Exceptions.ErrorMessages;
using TakeRecipeEasily.Infrastructure.Validation;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;

        public AuthenticationService(
            IPasswordHasher passwordHasher,
            IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _usersRepository
                .GetUserAsync(email)
                .ThrowIfNullAsync(ErrorType.NotFound, UsersErrorCodes.InvalidCredentials);

            _passwordHasher
                .VerifyPassword(user.HashedPassword, password)
                .ThrowIfFalse(ErrorType.NotFound, UsersErrorCodes.InvalidCredentials);
        }
    }
}
