using System;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesIngredients
{
    public sealed class RecipeIngredientCreateModel
    {
        public int Quantity { get; }
        public Guid RecipeId { get; }
        public Guid IngredientId { get; }
        public Unit Unit { get; }

        public RecipeIngredientCreateModel(int quantity, Guid recipeId, Guid ingredientId, Unit unit)
        {
            Quantity = quantity;
            RecipeId = recipeId;
            IngredientId = ingredientId;
            Unit = unit;
        }
    }
}
