﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.UpdateModels.Ingredients;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class IngredientsCommandService : IIngredientsCommandService
    {
        private readonly DatabaseContext _dbContext;

        public IngredientsCommandService(DatabaseContext dbContext) => _dbContext = dbContext;

        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            using (var transactionScope = new TransactionScope())
            {
                await _dbContext.Ingredients.AddAsync(ingredient);

                transactionScope.Complete();
            }
        }

        public async Task UpdateIngredientAsync(IngredientUpdateModel ingredientUpdateModel)
        {
            using (var transactionScope = new TransactionScope())
            {
                var ingredient = await GetIngredientAsync(ingredientUpdateModel.Id);
                ingredient.Update(ingredientUpdateModel.Name);
                _dbContext.Ingredients.Update(ingredient);

                transactionScope.Complete();
            }
        }

        private async Task<Ingredient> GetIngredientAsync(Guid ingredientId)
            => await _dbContext.Ingredients
                .Select(i => Ingredient.Create(i.Id, i.Name, i.IngredientCategoryId))
                .SingleAsync(i => i.Id == ingredientId);
    }
}
