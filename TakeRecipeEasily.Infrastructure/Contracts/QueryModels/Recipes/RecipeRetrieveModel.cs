using System;
using System.Collections.Generic;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesRatings;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes
{
    public class RecipeRetrieveModel
    {
        public Guid Id { get; set; }
        public int DifficultyLevel { get; set; }
        public int PreparationTime { get; set; }
        public int? TotalKcal { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string UserFullName { get; set; }
        public IEnumerable<IngredientRetrieveModel> Ingredients { get; set; }
        public IEnumerable<RecipeRatingRetrieveModel> RecipesRatings { get; set; }
    }
}
