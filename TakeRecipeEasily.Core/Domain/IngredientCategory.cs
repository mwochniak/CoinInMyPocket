using System;

namespace TakeRecipeEasily.Core.Domain
{
    public sealed class IngredientCategory : Entity
    {
        public string Name { get; }

        private IngredientCategory(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static IngredientCategory Create(Guid id, string name)
            => new IngredientCategory(id, name);
    }
}
