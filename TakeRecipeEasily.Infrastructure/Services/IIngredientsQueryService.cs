﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels.Ingredients;

namespace TakeRecipeEasily.Infrastructure.Services
{
    public interface IIngredientsQueryService : IServisable
    {
        Task<IngredientRetrieveModel> GetIngredientAsync(Guid ingredientId);

        Task<IEnumerable<IngredientRetrieveModel>> GetIngredientsAsync();
    }
}
