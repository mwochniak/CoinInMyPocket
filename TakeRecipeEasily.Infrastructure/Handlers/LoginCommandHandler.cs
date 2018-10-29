using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation;
using System.Threading.Tasks;
using Valit;

namespace TakeRecipeEasily.Infrastructure.Handlers
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task HandleCommandAsync(LoginCommand command)
        {
            ValidateModel(command);
            await _authenticationService.LoginAsync(command.Email, command.Password);
        }

        private void ValidateModel(LoginCommand command)
        {
            var result = ValitRules<LoginCommand>
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
