using CoinInMyPocket.Infrastructure.Contracts.Commands;
using CoinInMyPocket.Infrastructure.Services;
using System.Threading.Tasks;

namespace CoinInMyPocket.Infrastructure.Handlers
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task HandleCommandAsync(LoginCommand command)
            => await _authenticationService.LoginAsync(command.Email, command.Password);
    }
}
