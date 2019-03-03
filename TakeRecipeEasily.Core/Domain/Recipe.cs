using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.Domain
{
    public class Recipe : Entity
    {
        public int DifficultyLevel { get; private set; }
        public int PreparationTime { get; private set; }
        public int? TotalKcal { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
        public string Summary { get; private set; }
        public Guid UserId { get; private set; }

        public User User { get; private set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private set; }
        public virtual ICollection<RecipeImage> RecipeImages { get; private set; }
        public virtual ICollection<RecipeRating> RecipeRatings { get; private set; }

        private Recipe() {}

        private Recipe(Guid id, int difficultyLevel, int preparationTime, int? totalKcal, string description, string name, string summary, Guid userId)
        {
            Id = id;
            DifficultyLevel = difficultyLevel;
            PreparationTime = preparationTime;
            TotalKcal = totalKcal;
            Description = description;
            Name = name;
            Summary = summary;
            UserId = userId;
        }

        public static Recipe Create(
            Guid id,
            int difficultyLevel,
            int preparationTime,
            int? totalKcal,
            string description,
            string name,
            string summary,
            Guid userId)
            => new Recipe(
                id: id,
                difficultyLevel: difficultyLevel,
                preparationTime: preparationTime,
                totalKcal: totalKcal,
                description: description,
                name: name,
                summary: summary,
                userId: userId);

        public void Update(int difficultyLevel, int preparationTime, int? totalKcal, string description, string name, string summary)
        {
            DifficultyLevel = difficultyLevel;
            PreparationTime = preparationTime;
            TotalKcal = totalKcal;
            Description = description;
            Name = name;
            Summary = summary;
        }

        public void AddRecipeIngredients(ICollection<RecipeIngredient> recipeIngredients) => RecipeIngredients = recipeIngredients;
    }
}
