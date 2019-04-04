using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes
{
    public class RecipeImagePartialModel
    {
        public Guid Id { get; set; }
        public bool IsDefault { get; set; }
    }
}
