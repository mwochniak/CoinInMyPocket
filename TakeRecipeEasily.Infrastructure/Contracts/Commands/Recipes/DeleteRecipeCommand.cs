using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes
{
    public class DeleteRecipeCommand : ICommand
    {
        public Guid Id { get; }

        public DeleteRecipeCommand(Guid id)
        {
            Id = id;
        }
    }
}
