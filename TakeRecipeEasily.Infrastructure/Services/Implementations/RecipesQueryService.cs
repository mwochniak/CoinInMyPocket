using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesIngredients;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.RecipesRatings;
using TakeRecipeEasily.Infrastructure.Extensions;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class RecipesQueryService : IRecipesQueryService
    {
        private readonly DatabaseContext _dbContext;

        public RecipesQueryService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task<RecipeRetrieveModel> GetRecipeAsync(Guid recipeId)
        {
            var recipe = await _dbContext.Recipes.Where(r => r.Id == recipeId).Select(r => new RecipeRetrieveModel()
            {
                Id = r.Id,
                DifficultyLevel = r.DifficultyLevel,
                PreparationTime = r.PreparationTime,
                TotalKcal = r.TotalKcal,
                Description = r.Description,
                Name = r.Name,
                Summary = r.Summary,
                RecipeIngredients = r.RecipeIngredients.Select(ri => new RecipeIngredientRetrieveModel()
                {
                    IngredientId = ri.Ingredient.Id,
                    Quantity = ri.Quantity,
                    UnitName = Enum.GetName(typeof(Unit), ri.Unit),
                    IngredientName = ri.Ingredient.Name,
                    RecipeId = ri.Recipe.Id
                }),
                RecipeRatings = r.RecipeRatings.Select(rr => new RecipeRatingRetrieveModel()
                {
                    Id = rr.Id,
                    RecipeId = rr.RecipeId,
                    Rate = rr.Rate,
                    Comment = rr.Comment,
                    UserFullName = rr.User.FirstName + " " + rr.User.LastName,
                    UserId = rr.UserId
                }),
                UserId = r.UserId,
                UserFullName = r.User.FirstName + " " + r.User.LastName
            })
            .SingleOrDefaultAsync();

            recipe.AverageRate = recipe.RecipeRatings.Select(rr => rr.Rate).CalculateAvegare();

            return recipe;
        }

        public async Task<IEnumerable<RecipeRetrieveModel>> GetRecipesAsync()
        {
            var recipes = await _dbContext.Recipes.Select(r => new RecipeRetrieveModel()
            {
                Id = r.Id,
                DifficultyLevel = r.DifficultyLevel,
                PreparationTime = r.PreparationTime,
                TotalKcal = r.TotalKcal,
                Description = r.Description,
                Name = r.Name,
                Summary = r.Summary,
                RecipeIngredients = r.RecipeIngredients.Select(ri => new RecipeIngredientRetrieveModel()
                {
                    IngredientId = ri.Ingredient.Id,
                    Quantity = ri.Quantity,
                    UnitName = Enum.GetName(typeof(Unit), ri.Unit),
                    IngredientName = ri.Ingredient.Name,
                    RecipeId = ri.Recipe.Id
                }),
                RecipeRatings = r.RecipeRatings.Select(rr => new RecipeRatingRetrieveModel()
                {
                    RecipeId = rr.RecipeId,
                    Rate = rr.Rate,
                    Comment = rr.Comment,
                    UserFullName = rr.User.FirstName + " " + rr.User.LastName,
                    UserId = rr.UserId
                }),
                UserId = r.UserId,
                UserFullName = r.User.FirstName + " " + r.User.LastName
            })
            .ToListAsync();

            recipes.ForEach(r => r.AverageRate = r.RecipeRatings.Select(rr => rr.Rate).CalculateAvegare());

            return recipes;
        }

        public async Task<IEnumerable<RecipeRetrieveModel>> GetUserRecipesAsync(Guid userId)
        {
            var recipes = await _dbContext.Recipes.Where(r => r.UserId == userId).Select(r => new RecipeRetrieveModel()
            {
                Id = r.Id,
                DifficultyLevel = r.DifficultyLevel,
                PreparationTime = r.PreparationTime,
                TotalKcal = r.TotalKcal,
                Description = r.Description,
                Name = r.Name,
                Summary = r.Summary,
                RecipeIngredients = r.RecipeIngredients.Select(ri => new RecipeIngredientRetrieveModel()
                {
                    IngredientId = ri.Ingredient.Id,
                    Quantity = ri.Quantity,
                    UnitName = Enum.GetName(typeof(Unit), ri.Unit),
                    IngredientName = ri.Ingredient.Name,
                    RecipeId = ri.Recipe.Id
                }),
                RecipeRatings = r.RecipeRatings.Select(rr => new RecipeRatingRetrieveModel()
                {
                    RecipeId = rr.RecipeId,
                    Rate = rr.Rate,
                    Comment = rr.Comment,
                    UserFullName = rr.User.FirstName + " " + rr.User.LastName,
                    UserId = rr.UserId
                }),
                UserId = r.UserId,
                UserFullName = r.User.FirstName + " " + r.User.LastName
            })
            .ToListAsync();

            recipes.ForEach(r => r.AverageRate = r.RecipeRatings.Select(rr => rr.Rate).CalculateAvegare());

            return recipes;
        }
    }
}
