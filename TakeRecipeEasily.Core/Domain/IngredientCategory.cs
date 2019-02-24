using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Core.Domain
{
    public class IngredientCategory : Entity
    {
        public string Name { get; private set; }

        public virtual ICollection<Ingredient> Ingredients { get; private set; }

        private IngredientCategory() {}

        private IngredientCategory(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static IngredientCategory Create(Guid id, string name)
            => new IngredientCategory(id, name);
    }
}
