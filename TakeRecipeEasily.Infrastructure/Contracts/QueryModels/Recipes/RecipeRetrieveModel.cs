using System;
using System.Collections.Generic;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes
{
    public class RecipeRetrieveModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RecipeRating { get; set; }
        public Guid UserId { get; set; }
        public string UserFullName { get; set; }
        public IEnumerable<IngredientRetrieveModel> Ingredients { get; set; }
    }
}
