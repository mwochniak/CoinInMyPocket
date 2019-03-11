using System;
using System.Collections.Generic;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesIngredients;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes
{
    public class UpdateRecipeCommand : AuthenticatedCommand
    {
        public Guid Id { get; }
        public int DifficultyLevel { get; }
        public int PreparationTime { get; }
        public int? TotalKcal { get; }
        public string Description { get; }
        public string Name { get; }
        public string Summary { get; }
        public ICollection<RecipeIngredientUpdateModel> RecipeIngredients { get; }

        public UpdateRecipeCommand(
            Guid id,
            int difficultyLevel,
            int preparationTime,
            int? totalKcal,
            string description,
            string name,
            string summary,
            Guid userId,
            ICollection<RecipeIngredientUpdateModel> recipeIngredients)
        {
            Id = id;
            DifficultyLevel = difficultyLevel;
            PreparationTime = preparationTime;
            TotalKcal = totalKcal;
            Description = description;
            Name = name;
            Summary = summary;
            UserId = userId;
            RecipeIngredients = recipeIngredients;
        }
    }
}
