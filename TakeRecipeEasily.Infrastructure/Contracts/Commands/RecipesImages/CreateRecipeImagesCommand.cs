using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages
{
    public class CreateRecipeImagesCommand : AuthenticatedCommand
    {
        public Guid RecipeId { get; }
        public IEnumerable<RecipeImageCreateModel> RecipeImages { get; }

        public CreateRecipeImagesCommand(Guid recipeId, IEnumerable<RecipeImageCreateModel> recipeImages)
        {
            RecipeId = recipeId;
            RecipeImages = recipeImages;
        }
    }
}
