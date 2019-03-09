using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages
{
    public sealed class RecipeImageUpdateModel
    {
        public Guid Id { get; }
        public byte[] Content { get; }
        public bool IsDefault { get; }
        public string ContentType { get; }

        public RecipeImageUpdateModel(Guid id, byte[] content, bool isDefault, string contentType)
        {
            Id = id;
            Content = content;
            IsDefault = isDefault;
            ContentType = contentType;
        }
    }
}
