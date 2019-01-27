using System;

namespace TakeRecipeEasily.Core.UpdateModels.Ingredients
{
    public class IngredientUpdateModel
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
