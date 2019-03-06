﻿using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients
{
    public sealed class IngredientUpdateModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public Guid IngredientCategoryId { get; }

        private IngredientUpdateModel(Guid id, string name, Guid ingredientCategoryId)
        {
            Id = id;
            Name = name;
            IngredientCategoryId = ingredientCategoryId;
        }

        public static IngredientUpdateModel Create(Guid ingredientId, string name, Guid ingredientCategoryId)
            => new IngredientUpdateModel(ingredientId, name, ingredientCategoryId);
    }
}
