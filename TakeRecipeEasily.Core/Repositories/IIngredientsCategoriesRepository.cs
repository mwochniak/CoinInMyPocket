using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Abstractions;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Core.Repositories
{
    public interface IIngredientsCategoriesRepository : IRepositorable
    {
        Task CreateAsync(IngredientCategory ingredientCategory);

        Task<bool> IsNameInUse(string name);

        Task<IngredientCategory> GetAsync(Guid id);
        Task<IEnumerable<IngredientCategory>> GetAsync();
    }
}
