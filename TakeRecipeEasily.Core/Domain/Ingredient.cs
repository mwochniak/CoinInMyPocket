﻿using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.Domain
{
    public class Ingredient : Entity
    {
        public string Name { get; private set; }
        public Guid IngredientCategoryId { get; private set; }

        public virtual ICollection<IngredientCategoryIngredient> IngredientCategoriesIngredients { get; private set; }
        public virtual ICollection<RecipeIngredient> RecipesIngredients { get; private set; }

        private Ingredient() {}

        private Ingredient(Guid id, string name, Guid ingredientCategoryId)
        {
            Id = id;
            Name = name;
            IngredientCategoryId = ingredientCategoryId;
        }

        public static Ingredient Create(Guid ingredientId, string name, Guid ingredientCategoryId)
            => new Ingredient(ingredientId, name, ingredientCategoryId);

        public void Update(string name)
            => Name = name;
    }
}