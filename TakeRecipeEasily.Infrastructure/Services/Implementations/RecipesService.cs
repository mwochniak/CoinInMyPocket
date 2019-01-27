using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Core.UpdateModels.Recipes;
using TakeRecipeEasily.Infrastructure.Contracts.Extensions.Recipes;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Recipes;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class RecipesService : IRecipesService
    {
        private readonly IIngredientsRepository _ingredientsRepository;
        private readonly IRecipesRepository _recipesRepository;

        public RecipesService(IIngredientsRepository ingredientsRepository, IRecipesRepository recipesRepository)
        {
            _ingredientsRepository = ingredientsRepository;
            _recipesRepository = recipesRepository;
        }

        public async Task CreateRecipeAsync(Recipe recipe)
            => await _recipesRepository.CreateAsync(recipe);

        public async Task DeleteRecipeAsync(Guid id)
            => await _recipesRepository.DeleteAsync(id);

        public async Task UpdateRecipeAsync(RecipeUpdateModel recipeUpdateModel)
            => await _recipesRepository.UpdateAsync(recipeUpdateModel);

        public async Task<RecipeRetrieveModel> GetRecipeAsync(Guid id)
        {
            var recipe = await _recipesRepository.GetAsync(id);
            var ingredients = await _ingredientsRepository.GetAsync(recipe.RecipesIngredients.Select(ri => ri.IngredientId));
            return recipe.AsModel(ingredients);
        }
    }
}
