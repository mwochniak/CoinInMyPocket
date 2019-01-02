using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Abstractions;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Core.Repositories
{
    public interface IIngredientsRepository : IRepositorable
    {
        Task CreateAsync(Ingredient ingredient);
        Task UpdateAsync(Ingredient ingredient);

        Task<Ingredient> GetAsync(Guid ingredientId);
    }
}
