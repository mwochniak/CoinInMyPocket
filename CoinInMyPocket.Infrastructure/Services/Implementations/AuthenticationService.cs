using CoinInMyPocket.Core.Domain;
using CoinInMyPocket.Core.Repositories;
using CoinInMyPocket.Infrastructure.Exceptions.ErrorMessages;
using CoinInMyPocket.Infrastructure.Validation;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Services.Implementations
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
