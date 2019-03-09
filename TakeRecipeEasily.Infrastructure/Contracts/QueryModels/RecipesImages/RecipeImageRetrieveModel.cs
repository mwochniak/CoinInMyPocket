using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesImages
{
    public class RecipeImageRetrieveModel
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public bool IsDefault { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
