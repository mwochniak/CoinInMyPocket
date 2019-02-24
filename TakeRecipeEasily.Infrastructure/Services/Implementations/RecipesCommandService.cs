using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.UpdateModels.Recipes;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class RecipesCommandService : IRecipesCommandService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesCommandService(DatabaseContext context) => _dbContext = context;

        public async Task CreateRecipeAsync(Recipe recipe, IEnumerable<Guid> ingredientsIds)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                recipe.AddRecipeIngredients(ingredientsIds);
                await _dbContext.Recipes.AddAsync(recipe);
                await _dbContext.RecipesRatings.AddAsync(RecipeRating.Create(recipe.RecipeRatingId, 0, recipe.Id));

                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        public async Task DeleteRecipeAsync(Guid recipeId)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var recipe = await GetRecipeAsync(recipeId);
                var recipeIngredients = await _dbContext.RecipesIngredients.Where(ri => ri.RecipeId == recipeId).ToListAsync();
                var recipeRating = await _dbContext.RecipesRatings.SingleOrDefaultAsync(rr => rr.RecipeId == recipeId);

                _dbContext.RecipesIngredients.RemoveRange(recipeIngredients);
                _dbContext.Recipes.Remove(recipe);
                _dbContext.RecipesRatings.Remove(recipeRating);

                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        public async Task UpdateRecipeAsync(RecipeUpdateModel recipeUpdateModel)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var recipe = await GetRecipeAsync(recipeUpdateModel.Id);
                var recipeIngredients = await _dbContext.RecipesIngredients.Where(ri => ri.RecipeId == recipeUpdateModel.Id).ToListAsync();

                var recipeIngredientsIdsToAdd = recipeUpdateModel.IngredientsIds.Where(r => !recipeIngredients.Select(ri => ri.IngredientId).Contains(r)).ToList();
                var recipeIngredientsToRemove = recipeIngredients.Where(ri => !recipeUpdateModel.IngredientsIds.ToList().Contains(ri.IngredientId));

                recipe.Update(recipeUpdateModel.Name, recipeUpdateModel.Description);
                _dbContext.Update(recipe);

                await _dbContext.RecipesIngredients.AddRangeAsync(RecipeIngredient.Create(recipeUpdateModel.Id, recipeIngredientsIdsToAdd));
                _dbContext.RemoveRange(recipeIngredientsToRemove);

                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        private async Task<Recipe> GetRecipeAsync(Guid recipeId)
            => await _dbContext.Recipes.Select(r => Recipe.Create(r.Id, r.Name, r.Description, r.RecipeRatingId, r.UserId)).SingleOrDefaultAsync(r => r.Id == recipeId);
    }
}
