using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Core.UpdateModels.Ingredients;
using TakeRecipeEasily.Infrastructure.Contracts.Extensions.Ingredients;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientsRepository _ingredientsRepository;

        public IngredientsService(IIngredientsRepository ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }

        public async Task CreateIngredientAsync(Ingredient ingredient)
            => await _ingredientsRepository.CreateAsync(ingredient);

        public async Task UpdateIngredientAsync(IngredientUpdateModel ingredientUpdateModel)
        {
            var ingredient = await _ingredientsRepository.GetAsync(ingredientUpdateModel.Id);
            ingredient.Update(ingredientUpdateModel.Name);
            await _ingredientsRepository.UpdateAsync(ingredient);
        }

        public async Task<IngredientRetrieveModel> GetIngredientAsync(Guid ingredientId)
            => await _ingredientsRepository.GetAsync(ingredientId).AsModel();
    }
}
