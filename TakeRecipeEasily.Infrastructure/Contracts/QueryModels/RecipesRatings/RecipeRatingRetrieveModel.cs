using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesRatings
{
    public class RecipeRatingRetrieveModel
    {
        public int Rate { get; set; }
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public string UserFullName { get; set; }
    }
}
