using System;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Handlers
{
    public class Handler : IHandler
    {
        private Func<Task> _handle;

        public IHandler Validate(Action validate)
        {
            validate.Invoke();

            return this;
        }

        public IHandler Handle(Func<Task> handle)
        {
            _handle = handle;

            return this;
        }

        public async Task ExecuteAsync()
            => await _handle();
    }
}
