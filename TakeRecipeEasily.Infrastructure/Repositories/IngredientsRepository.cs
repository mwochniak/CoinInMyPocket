﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Core.UpdateModels.Ingredients;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly TakeRecipeEasilyContext _context;

        public IngredientsRepository(TakeRecipeEasilyContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task<Ingredient> GetAsync(Guid ingredientId)
            => await _context.Ingredients.SingleOrDefaultAsync(i => i.Id == ingredientId);

        public async Task UpdateAsync(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();
        }
    }
}
