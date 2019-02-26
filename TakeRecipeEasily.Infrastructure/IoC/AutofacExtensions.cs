using Autofac;
using TakeRecipeEasily.Core.Abstractions;
using TakeRecipeEasily.Infrastructure.Services;

namespace TakeRecipeEasily.Infrastructure.IoC
{
    public static class AutofacExtensions
    {
        public static void Register<TImplementations, TInterface>(this ContainerBuilder containerBuilder)
            => containerBuilder.RegisterType<TImplementations>().As<TInterface>();

        public static void Register<TImlementations>(this ContainerBuilder containerBuilder)
            => containerBuilder.RegisterType<TImlementations>().AsSelf();

        public static void RegisterService<TService, IService>(this ContainerBuilder containerBuilder) where TService : IServisable
            => containerBuilder.Register<TService, IService>();

        public static void RegisterService<TService>(this ContainerBuilder containerBuilder) where TService : IServisable
            => containerBuilder.Register<TService>();
    }
}
