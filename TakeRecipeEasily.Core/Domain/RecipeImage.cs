using System;

namespace TakeRecipeEasily.Core.Domain
{
    public sealed class RecipeImage : Entity
    {
        public byte[] Content { get; private set; }
        public Guid RecipeId { get; private set; }
        public bool IsDefault { get; private set; }
        public string ContentType { get; private set; }

        public Recipe Recipe { get; private set; }

        private RecipeImage() { }

        private RecipeImage(Guid id, byte[] content, Guid recipeId, bool isDefault, string contentType)
        {
            Id = id;
            Content = content;
            RecipeId = recipeId;
            IsDefault = isDefault;
            ContentType = contentType;
        }

        public static RecipeImage Create(Guid id, byte[] content, Guid recipeId, bool isDefault, string contentType)
            => new RecipeImage(id: id, content: content, recipeId: recipeId, isDefault: isDefault, contentType: contentType);

        public void Update(bool isDefault, byte[] content, string contentType)
        {
            IsDefault = isDefault;
            Content = content;
            ContentType = contentType;
        }
    }
}
