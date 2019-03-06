using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Infrastructure.Busses;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorize]
    [Route("units")]
    public class UnitsController : ApiControllerBase
    {
        public UnitsController(ICommandsBus commandsBus) : base(commandsBus)
        {
        }

        [HttpGet("")]
        public Task<string[]> GetUnitsAsync()
            => Task.FromResult(Enum.GetNames(typeof(Unit)));
    }
}
