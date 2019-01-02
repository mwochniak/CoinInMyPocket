using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Core.UpdateModels.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientsRepository _ingredientsRepository;

        public IngredientService(IIngredientsRepository ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }

        public async Task CreateIngredientAsync(Ingredient ingredient)
            => await _ingredientsRepository.CreateAsync(ingredient);

        public async Task<Ingredient> GetIngredientAsync(Guid ingredientId)
            => await _ingredientsRepository.GetAsync(ingredientId);

        public async Task UpdateIngredientAsync(IngredientUpdateModel ingredientUpdateModel)
        {
            var ingredient = await _ingredientsRepository.GetAsync(ingredientUpdateModel.Id);
            ingredient.Update(ingredientUpdateModel.Name);
            await _ingredientsRepository.UpdateAsync(ingredient);
        }
    }
}
