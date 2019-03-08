using System;

namespace TakeRecipeEasily.Core.Domain
{
    public sealed class RecipeIngredient
    {
        public double Quantity { get; private set; }
        public Guid RecipeId { get; private set; }
        public Guid IngredientId { get; private set; }
        public Unit Unit { get; private set; }

        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }

        public RecipeIngredient() { }

        private RecipeIngredient(Guid recipeId, Guid ingredientId, Unit unit, double quantity)
        {
            RecipeId = recipeId;
            IngredientId = ingredientId;
            Unit = unit;
            Quantity = quantity;
        }

        public static RecipeIngredient Create(Guid recipeId, Unit unit, double quantity, Guid ingredientId)
            =>  new RecipeIngredient(recipeId: recipeId, ingredientId: ingredientId, unit: unit, quantity: quantity);
    }
}
