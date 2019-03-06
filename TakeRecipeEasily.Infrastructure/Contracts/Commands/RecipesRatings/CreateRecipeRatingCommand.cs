using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings
{
    public class CreateRecipeRatingCommand : AuthenticatedCommand
    {
        public Guid Id { get; }
        public Guid RecipeId { get; }
        public int Rate { get; }
        public string Comment { get; }

        public CreateRecipeRatingCommand(Guid recipeId, int rate, string comment)
        {
            Id = Guid.NewGuid();
            RecipeId = recipeId;
            Rate = rate;
            Comment = comment;
        }
    }
}
