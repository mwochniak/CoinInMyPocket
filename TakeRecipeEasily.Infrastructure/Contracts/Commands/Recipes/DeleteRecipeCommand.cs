using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes
{
    public class DeleteRecipeCommand : AuthenticatedCommand
    {
        public Guid Id { get; }

        public DeleteRecipeCommand(Guid id)
        {
            Id = id;
        }
    }
}
