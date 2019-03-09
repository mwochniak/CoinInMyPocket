using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Users;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Services.Users;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Users
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IHandler _handler;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersCommandService _usersCommandService;

        public CreateUserCommandHandler(
            IHandler handler,
            IPasswordHasher passwordHasher,
            IUsersCommandService usersCommandService)
        {
            _handler = handler;
            _passwordHasher = passwordHasher;
            _usersCommandService = usersCommandService;
        }

        public async Task HandleCommandAsync(CreateUserCommand command)
            => await _handler
                .Validate(() => UsersCommandModelsValidation.CreateUserCommandValidation(command))
                .Handle(async () => await _usersCommandService.CreateUserAsync(User.Create(command.Id, command.Email, command.FirstName, command.LastName, _passwordHasher.HashPassword(command.Password))))
                .ExecuteAsync();
    }
}
