using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesIngredients
{
    public class RecipeIngredientRetrieveModel
    {
        public int Quantity { get; set; }
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public string UnitName { get; set; }
        public string IngredientName { get; set; }
    }
}
