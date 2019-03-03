using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.Domain
{
    public class Ingredient : Entity
    {
        public string Name { get; private set; }
        public Guid IngredientCategoryId { get; private set; }

        public IngredientCategory IngredientCategory { get; private set; }

        public virtual ICollection<RecipeIngredient> RecipesIngredients { get; private set; }

        private Ingredient() {}

        private Ingredient(Guid id, string name, Guid ingredientCategoryId)
        {
            Id = id;
            Name = name;
            IngredientCategoryId = ingredientCategoryId;
        }

        public static Ingredient Create(Guid ingredientId, string name, Guid ingredientCategoryId)
            => new Ingredient(id: ingredientId, name: name, ingredientCategoryId: ingredientCategoryId);

        public void Update(string name, Guid ingredientCategoryId)
        {
            Name = name;
            IngredientCategoryId = ingredientCategoryId;
        }
    }
}
