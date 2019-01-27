﻿using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients
{
    public class CreateIngredientCommand : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Guid IngredientCategoryId { get; }
        public string Name { get; }

        public CreateIngredientCommand(Guid id, Guid ingredientCategoryId, string name)
        {
            Id = id;
            IngredientCategoryId = ingredientCategoryId;
            Name = name;
        }
    }
}
