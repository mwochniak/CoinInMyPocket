using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Infrastructure.Contracts.Extensions.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Exceptions.ErrorMessages;
using TakeRecipeEasily.Infrastructure.Validation;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class IngredientsCategoriesService : IIngredientsCategoriesService
    {
        private readonly IIngredientsCategoriesRepository _ingredientCategoryRepository;

        public IngredientsCategoriesService(IIngredientsCategoriesRepository ingredientCategoryRepository)
        {
            _ingredientCategoryRepository = ingredientCategoryRepository;
        }

        public async Task CreateIngredientCategoryAsync(Guid id, string name)
        {
            await _ingredientCategoryRepository.IsNameInUse(name).ThrowIfTrueAsync(ErrorType.Conflict, IngredientsCategoriesErrorCodes.IngredientCategoryNameIsInUse);

            var ingredientCategory = IngredientCategory.Create(id, name);
            await _ingredientCategoryRepository.AddAsync(ingredientCategory);
        }

        public async Task<IngredientCategoryRetrieveModel> GetIngredientCategoryAsync(Guid id)
            => await _ingredientCategoryRepository
                .GetIngredientCategoryAsync(id)
                .ThrowIfNullAsync(ErrorType.NotFound, IngredientsCategoriesErrorCodes.IngredientCategoryDoesNotExists)
                .AsModel();
    }
}
