using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Users
{
    public class CreateUserCommand : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
