using System;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesIngredients
{
    public class RecipeIngredientRetrieveModel
    {
        public int Quantity { get; set; }
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public Unit Unit { get; set; }
    }
}
