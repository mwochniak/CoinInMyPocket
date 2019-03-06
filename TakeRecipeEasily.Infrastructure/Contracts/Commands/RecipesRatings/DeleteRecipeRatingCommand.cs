using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings
{
    public class DeleteRecipeRatingCommand : AuthenticatedCommand
    {
        public Guid Id { get; }

        public DeleteRecipeRatingCommand(Guid id)
        {
            Id = id;
        }
    }
}
