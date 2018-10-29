using TakeRecipeEasily.Core.Abstractions;
using System;

namespace TakeRecipeEasily.Core.Domain
{
    public class Entity : IIdentifiable
    {
        public Guid Id { get; set; }
    }
}
