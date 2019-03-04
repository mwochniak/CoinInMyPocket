using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Api.Controllers
{
    [Authorize]
    public class UnitsController : ApiControllerBase
    {
        public UnitsController(Infrastructure.Busses.ICommandsBus commandsBus) : base(commandsBus)
        {
        }

        [HttpGet("")]
        public Task<Array> GetUnitsAsync()
            => Task.FromResult(Enum.GetValues(typeof(Unit)));
    }
}
