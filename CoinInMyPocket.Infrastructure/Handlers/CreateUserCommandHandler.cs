using CoinInMyPocket.Infrastructure.Contracts.Commands;
using CoinInMyPocket.Infrastructure.Services;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersService _usersService;

        public CreateUserCommandHandler(
            IPasswordHasher passwordHasher,
            IUsersService usersService)
        {
            _passwordHasher = passwordHasher;
            _usersService = usersService;
        }

        public async Task HandleCommandAsync(CreateUserCommand command)
            => await _usersService.CreateUserAsync(
                command.Id,
                command.Email,
                command.FirstName,
                command.LastName,
                _passwordHasher.HashPassword(command.Password));
    }
}
