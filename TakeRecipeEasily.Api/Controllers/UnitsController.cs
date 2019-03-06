using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorize]
    [Route("units")]
    public class UnitsController : ApiControllerBase
    {
        public UnitsController(Infrastructure.Busses.ICommandsBus commandsBus) : base(commandsBus)
        {
        }

        [HttpGet("")]
        public Task<string[]> GetUnitsAsync()
            => Task.FromResult(Enum.GetNames(typeof(Unit)));
    }
}
