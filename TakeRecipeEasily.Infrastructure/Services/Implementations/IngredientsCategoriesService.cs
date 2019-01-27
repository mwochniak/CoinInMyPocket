using System;
using System.Collections.Generic;
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

        public async Task CreateIngredientCategoryAsync(IngredientCategory ingredientCategory)
        {
            await _ingredientCategoryRepository.IsNameInUse(ingredientCategory.Name).ThrowIfTrueAsync(ErrorType.Conflict, IngredientsCategoriesErrorCodes.IngredientCategoryNameIsInUse);
            await _ingredientCategoryRepository.CreateAsync(ingredientCategory);
        }

        public async Task<IngredientCategoryRetrieveModel> GetIngredientCategoryAsync(Guid id)
            => await _ingredientCategoryRepository
                .GetAsync(id)
                .ThrowIfNullAsync(ErrorType.NotFound, IngredientsCategoriesErrorCodes.IngredientCategoryDoesNotExists)
                .AsModel();

        public async Task<IEnumerable<IngredientCategoryRetrieveModel>> GetIngredientCategoriesAsync()
            => await _ingredientCategoryRepository
                .GetAsync()
                .AsModels();
    }
}
