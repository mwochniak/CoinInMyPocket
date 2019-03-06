﻿using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesRatings
{
    public class UpdateRecipeRatingCommand : AuthenticatedCommand
    {
        public Guid Id { get; }
        public Guid RecipeId { get; }
        public int Rate { get; }
        public string Comment { get; }

        public UpdateRecipeRatingCommand(Guid id, Guid recipeId, int rate, string comment)
        {
            Id = id;
            RecipeId = recipeId;
            Rate = rate;
            Comment = comment;
        }
    }
}
