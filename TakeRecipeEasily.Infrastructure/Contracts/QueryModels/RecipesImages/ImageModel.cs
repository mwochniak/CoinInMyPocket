using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesImages
{
    public class ImageModel
    {
        public Guid Id { get; set; }
        public bool IsDefault { get; set; }
        public byte[] Content { get; set; }
    }
}
