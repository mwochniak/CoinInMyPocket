using System;

namespace TakeRecipeEasily.Core.Domain
{
    public sealed class RecipeImage : Entity
    {
        public byte[] Content { get; private set; }
        public Guid RecipeId { get; private set; }
        public bool IsDefault { get; private set; }

        public Recipe Recipe { get; private set; }

        private RecipeImage() { }

        private RecipeImage(Guid id, byte[] content, Guid recipeId, bool isDefault)
        {
            Id = id;
            Content = content;
            RecipeId = recipeId;
            IsDefault = isDefault;
        }

        public static RecipeImage Create(Guid id, byte[] content, Guid recipeId, bool isDefault)
            => new RecipeImage(id: id, content: content, recipeId: recipeId, isDefault: isDefault);

        public void Update(bool isDefault)
            => IsDefault = isDefault;
    }
}
