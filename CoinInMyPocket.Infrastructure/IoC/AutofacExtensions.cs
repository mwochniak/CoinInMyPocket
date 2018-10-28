using Autofac;
using CoinInMyPocket.Core.Abstractions;
using CoinInMyPocket.Infrastructure.Services;

namespace CoinInMyPocket.Infrastructure.IoC
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

        public static void RegisterRepository<TRepository, IRepository>(this ContainerBuilder containerBuilder) where TRepository : IRepositorable
            => containerBuilder.Register<TRepository, IRepository>();

        public static void RegisterRepository<TRepository>(this ContainerBuilder containerBuilder) where TRepository : IRepositorable
            => containerBuilder.Register<TRepository>();
    }
}
