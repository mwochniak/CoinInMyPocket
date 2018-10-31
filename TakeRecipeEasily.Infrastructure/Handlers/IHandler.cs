using System;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Handlers
{
    public interface IHandler
    {
        IHandler Validate(Action validate);
        IHandler Handle(Func<Task> handle);
        Task ExecuteAsync();
    }
}
