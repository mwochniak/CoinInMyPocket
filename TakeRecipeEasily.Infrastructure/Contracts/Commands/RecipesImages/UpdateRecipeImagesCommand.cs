using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages
{
    public class UpdateRecipeImagesCommand : AuthenticatedCommand
    {
        public Guid RecipeId { get; }
        public IEnumerable<RecipeImageUpdateModel> RecipeImages { get; }

        public UpdateRecipeImagesCommand(Guid recipeId, IEnumerable<RecipeImageUpdateModel> recipeImages)
        {
            RecipeId = recipeId;
            RecipeImages = recipeImages;
        }
    }
}
