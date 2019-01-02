using System;

namespace TakeRecipeEasily.Core.UpdateModels.Ingredients
{
    public class IngredientUpdateModel
    {
        public Guid Id { get; }
        public string Name { get; }

        public IngredientUpdateModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
