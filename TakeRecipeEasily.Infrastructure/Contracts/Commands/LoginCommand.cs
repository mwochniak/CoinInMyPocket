namespace TakeRecipeEasily.Infrastructure.Contracts.Commands
{
    public class LoginCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
