using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands
{
    public class AuthenticatedCommand : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
    }
}
