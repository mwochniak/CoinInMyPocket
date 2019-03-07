using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Api.Controllers
{
    public class RecipesRatingsController : ApiControllerBase
    {
        private readonly IRecipesRatingsQueryService _recipesRatingsQueryService;

        public RecipesRatingsController(ICommandsBus commandsBus, IRecipesRatingsQueryService recipesRatingsQueryService) : base(commandsBus)
            => _recipesRatingsQueryService = recipesRatingsQueryService;


    }
}
