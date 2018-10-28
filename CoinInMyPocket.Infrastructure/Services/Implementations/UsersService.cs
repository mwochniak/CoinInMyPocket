using CoinInMyPocket.Core.Abstractions;
using CoinInMyPocket.Core.Domain;
using CoinInMyPocket.Core.Repositories;
using CoinInMyPocket.Infrastructure.Contracts.Extensions;
using CoinInMyPocket.Infrastructure.Contracts.QueryModels;
using CoinInMyPocket.Infrastructure.Exceptions;
using CoinInMyPocket.Infrastructure.Exceptions.ErrorMessages;
using System;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task CreateUserAsync(Guid id, string email, string firstName, string lastName, string hashedPassword)
        {
            var isEmailInUse = await _usersRepository.IsEmailInUse(email);

            if (isEmailInUse)
            {
                throw new ServiceException(ErrorType.Conflict, UsersErrorCodes.EmailIsInUse);
            }

            var user = User.Create(id, email, firstName, lastName, hashedPassword);
            await _usersRepository.AddAsync(user);
        }

        public async Task<UserRetrieveModel> GetUserAsync(Guid id)
        {
            var user = await _usersRepository.GetUserAsync(id);

            if (user is null)
            {
                throw new ServiceException(ErrorType.NotFound, UsersErrorCodes.UserDoesNotExists);
            }

            return user.AsModel();
        }

        public async Task<UserRetrieveModel> GetUserAsync(string email)
        {
            var user = await _usersRepository.GetUserAsync(email);

            if (user is null)
            {
                throw new ServiceException(ErrorType.NotFound, UsersErrorCodes.UserDoesNotExists);
            }

            return user.AsModel();
        }
    }
}
