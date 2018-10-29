using System;

namespace TakeRecipeEasily.Core.Abstractions
{
    internal interface IIdentifiable
    {
        Guid Id { get; set; }
    }
}
