using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.RecipesIngredients;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class RecipesCommandService : IRecipesCommandService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesCommandService(DatabaseContext context) => _dbContext = context;

        public async Task CreateRecipeAsync(Recipe recipe, ICollection<RecipeIngredientCreateModel> recipeIngredients)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                recipe.AddRecipeIngredients(recipeIngredients.ToList().Select(ri => RecipeIngredient.Create(recipeId: recipe.Id , unit: ri.Unit, quantity: ri.Quantity, ingredientId: ri.IngredientId)).ToHashSet());
                await _dbContext.Recipes.AddAsync(recipe);

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
                var recipeRatings = await _dbContext.RecipesRatings.Where(rr => rr.RecipeId == recipeId).ToListAsync();
                var recipeImages = await _dbContext.RecipesImages.Where(ri => ri.RecipeId == recipeId).ToListAsync();

                _dbContext.RecipesIngredients.RemoveRange(recipeIngredients);
                _dbContext.RecipesRatings.RemoveRange(recipeRatings);
                _dbContext.RecipesImages.RemoveRange(recipeImages);
                _dbContext.Recipes.Remove(recipe);

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

                var recipeIngredientsUpdateModelsToAdd = recipeUpdateModel.RecipeIngredients.Where(r => !recipeIngredients.Select(ri => ri.IngredientId).Contains(r.IngredientId)).ToList();
                var recipeIngredientsToAdd = recipeIngredientsUpdateModelsToAdd.Select(ri => RecipeIngredient.Create(recipeId: recipeUpdateModel.Id, unit: ri.Unit, quantity: ri.Quantity, ingredientId: ri.IngredientId)).ToList();
                var recipeIngredientsToRemove = recipeIngredients.Where(ri => !recipeUpdateModel.RecipeIngredients.Select(uri => uri.IngredientId).ToList().Contains(ri.IngredientId)).ToList();

                recipe.Update(
                    difficultyLevel: recipeUpdateModel.DifficultyLevel,
                    preparationTime: recipeUpdateModel.PreparationTime,
                    totalKcal: recipeUpdateModel.TotalKcal,
                    description: recipeUpdateModel.Description,
                    name: recipeUpdateModel.Name,
                    summary: recipeUpdateModel.Summary);
                _dbContext.Recipes.Update(recipe);

                await _dbContext.RecipesIngredients.AddRangeAsync(recipeIngredientsToAdd);
                _dbContext.RemoveRange(recipeIngredientsToRemove);

                await _dbContext.SaveChangesAsync();
                transactionScope.Complete();
            }
        }

        private async Task<Recipe> GetRecipeAsync(Guid recipeId)
            => await _dbContext.Recipes
            .Select(r => Recipe.Create(
                r.Id,
                r.DifficultyLevel,
                r.PreparationTime,
                r.TotalKcal,
                r.Description,
                r.Name,
                r.Summary,
                r.UserId))
            .SingleOrDefaultAsync(r => r.Id == recipeId);
    }
}
