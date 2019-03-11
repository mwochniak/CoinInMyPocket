using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Infrastructure.Services.Ingredients
{
    public interface IIngredientsCommandService : IServisable
    {
        Task CreateIngredientAsync(Ingredient ingredient);
    }
}
