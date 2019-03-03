using System;
using System.Collections.Generic;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesIngredients;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes
{
    public sealed class RecipeUpdateModel
    {
        public Guid Id { get; }
        public int DifficultyLevel { get; }
        public int PreparationTime { get; }
        public int? TotalKcal { get; }
        public string Description { get; }
        public string Name { get; }
        public string Summary { get; }
        public ICollection<RecipeIngredientUpdateModel> RecipeIngredients { get; }

        private RecipeUpdateModel(Guid id, int difficultyLevel, int preparationTime, int? totalKcal, string description, string name, string summary, ICollection<RecipeIngredientUpdateModel> recipeIngredients)
        {
            Id = id;
            DifficultyLevel = difficultyLevel;
            PreparationTime = preparationTime;
            TotalKcal = totalKcal;
            Description = description;
            Name = name;
            Summary = summary;
            RecipeIngredients = recipeIngredients;
        }

        public static RecipeUpdateModel Create(
            Guid id,
            int difficultyLevel,
            int preparationTime,
            int? totalKcal,
            string description,
            string name,
            string summary,
            ICollection<RecipeIngredientUpdateModel> recipeIngredients)
            => new RecipeUpdateModel(
                id: id,
                difficultyLevel: difficultyLevel,
                preparationTime: preparationTime,
                totalKcal: totalKcal,
                description: description,
                name: name,
                summary: summary,
                recipeIngredients: recipeIngredients);
    }
}
