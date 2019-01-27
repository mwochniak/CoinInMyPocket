using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.UpdateModels.Recipes
{
    public class RecipeUpdateModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Guid RecipeRatingId { get; }
        public Guid UserId { get; }
        public IEnumerable<Guid> IngredientsIds { get; set; }

        private RecipeUpdateModel(Guid id, string name, string description, Guid recipeRatingId, Guid userId, IEnumerable<Guid> ingredientsIds)
        {
            Id = id;
            Name = name;
            Description = description;
            RecipeRatingId = recipeRatingId;
            UserId = userId;
            IngredientsIds = ingredientsIds;
        }

        public static RecipeUpdateModel Create(Guid id, string name, string description, Guid recipeRatingId, Guid userId, IEnumerable<Guid> ingredientsIds)
            => new RecipeUpdateModel(id, name, description, recipeRatingId, userId, ingredientsIds);
    }
}
