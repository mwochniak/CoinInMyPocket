using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes
{
    public class RecipeSearcherModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DifficultyLevel { get; set; }
        public int PreparationTime { get; set; }
        public double AverageRate { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
    }
}
