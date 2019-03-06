using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesImages
{
    public class RecipeImageCreateModel
    {
        public Guid Id { get; }
        public byte[] Content { get; }
        public bool IsDefault { get; }

        public RecipeImageCreateModel(byte[] content, bool isDefault)
        {
            Id = Guid.NewGuid();
            Content = content;
            IsDefault = isDefault;
        }
    }
}
