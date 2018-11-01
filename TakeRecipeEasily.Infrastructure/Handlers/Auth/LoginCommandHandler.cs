using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Auth;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Validation.CommandModelsValidation;

namespace TakeRecipeEasily.Infrastructure.Handlers.Auth
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IHandler _handler;

        public LoginCommandHandler(
            IAuthenticationService authenticationService,
            IHandler handler)
        {
            _authenticationService = authenticationService;
            _handler = handler;
        }

        public async Task HandleCommandAsync(LoginCommand command)
            => await _handler
                .Validate(() => AuthCommandModelsValidation.LoginCommandValidation(command))
                .Handle(async () => await _authenticationService.LoginAsync(command.Email, command.Password))
                .ExecuteAsync();
    }
}
