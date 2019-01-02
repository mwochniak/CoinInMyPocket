﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly TakeRecipeEasilyContext _context;

        public RecipesRepository(TakeRecipeEasilyContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<Recipe> GetAsync(Guid recipeId)
            => await _context.Recipes.SingleOrDefaultAsync(r => r.Id == recipeId);
    }
}
