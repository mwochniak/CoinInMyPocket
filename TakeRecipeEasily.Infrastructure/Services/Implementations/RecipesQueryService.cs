using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class RecipesQueryService : IRecipesQueryService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesQueryService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task<RecipeRetrieveModel> GetRecipeAsync(Guid recipeId)
            => await _dbContext.Recipes.Where(r => r.Id == recipeId).Select(r => new RecipeRetrieveModel()
            {
                Id = r.Id,
                Description = r.Description,
                Name = r.Name,
                Ingredients = r.RecipesIngredients.Select(ri => new IngredientRetrieveModel()
                {
                    Id = ri.Ingredient.Id,
                    IngredientCategoryId = ri.Ingredient.IngredientCategoryId,
                    Name = ri.Ingredient.Name
                }),
                RecipeRating = r.RecipeRating.Rate,
                UserId = r.UserId,
                UserFullName = r.User.FirstName + " " + r.User.LastName
            })
            .SingleAsync();
    }
}
