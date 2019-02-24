using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands
{
    public class Command : ICommand
    {
        public Guid UserId { get; set; }
    }
}
