namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Auth
{
    public class LoginCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
