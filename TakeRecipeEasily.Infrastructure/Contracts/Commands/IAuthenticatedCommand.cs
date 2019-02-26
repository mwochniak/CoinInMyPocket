using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
