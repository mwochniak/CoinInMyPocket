using CoinInMyPocket.Core.Domain;
using CoinInMyPocket.Core.Repositories;
using CoinInMyPocket.Infrastructure.Exceptions;
using CoinInMyPocket.Infrastructure.Exceptions.ErrorMessages;
using System;
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
            var user = await _usersRepository.GetUserAsync(email);

            if (user is null)
            {
                throw new ServiceException(ErrorType.NotFound, UsersErrorCodes.InvalidCredentials);
            }

            if (!_passwordHasher.VerifyPassword(user.HashedPassword, password))
            {
                throw new ServiceException(ErrorType.NotFound, UsersErrorCodes.InvalidCredentials);
            }
        }
    }
}
