using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation;
using System.Threading.Tasks;
using Valit;

namespace TakeRecipeEasily.Infrastructure.Handlers
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
                .Validate(() => ValidateModel(command))
                .Handle(async () => await _usersService.CreateUserAsync(
                    command.Id,
                    command.Email,
                    command.FirstName,
                    command.LastName,
                    _passwordHasher.HashPassword(command.Password)))
                .ExecuteAsync();

        private void ValidateModel(CreateUserCommand command)
        {
            var result = ValitRules<CreateUserCommand>
                .Create()
                .Ensure(c => c.Email, _ => _
                    .Required()
                    .Email())
                .Ensure(c => c.Password, _ => _
                    .Required()
                    .MinLength(8))
                .For(command)
                .Validate();

            result.Succeeded.ThrowIfFalse(ErrorType.BadRequest, string.Join(" ", result.ErrorMessages));
        }
    }
}
