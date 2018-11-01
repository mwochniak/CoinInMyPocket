using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Users;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Users
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IHandler _handler;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersService _usersService;

        public CreateUserCommandHandler(
            IHandler handler,
            IPasswordHasher passwordHasher,
            IUsersService usersService)
        {
            _handler = handler;
            _passwordHasher = passwordHasher;
            _usersService = usersService;
        }

        public async Task HandleCommandAsync(CreateUserCommand command)
            => await _handler
                .Validate(() => UsersCommandModelsValidation.CreateUserCommandValidation(command))
                .Handle(async () => await _usersService.CreateUserAsync(
                    command.Id,
                    command.Email,
                    command.FirstName,
                    command.LastName,
                    _passwordHasher.HashPassword(command.Password)))
                .ExecuteAsync();
    }
}
