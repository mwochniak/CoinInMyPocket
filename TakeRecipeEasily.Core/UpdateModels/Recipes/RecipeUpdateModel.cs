using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.UpdateModels.Recipes
{
    public sealed class RecipeUpdateModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public IEnumerable<Guid> IngredientsIds { get; set; }

        private RecipeUpdateModel(Guid id, string name, string description, IEnumerable<Guid> ingredientsIds)
        {
            Id = id;
            Name = name;
            Description = description;
            IngredientsIds = ingredientsIds;
        }

        public static RecipeUpdateModel Create(Guid id, string name, string description, IEnumerable<Guid> ingredientsIds)
            => new RecipeUpdateModel(id, name, description, ingredientsIds);
    }
}
