using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.Domain
{
    public class Ingredient : Entity
    {
        public string Name { get; private set; }

        public virtual ICollection<IngredientCategoryIngredient> IngredientCategoriesIngredients { get; private set; }
        public virtual ICollection<RecipeIngredient> RecipesIngredients { get; private set; }

        private Ingredient(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Ingredient Create(Guid id, string name)
            => new Ingredient(id, name);
    }
}
