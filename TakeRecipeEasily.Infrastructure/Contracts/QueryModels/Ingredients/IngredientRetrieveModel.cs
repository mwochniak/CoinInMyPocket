using System;

namespace TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients
{
    public class IngredientRetrieveModel
    {
        public Guid Id { get; set; }
        public Guid IngredientCategoryId { get; set; }
        public string IngredientCategoryName { get; set; }
        public string Name { get; set; }
    }
}
