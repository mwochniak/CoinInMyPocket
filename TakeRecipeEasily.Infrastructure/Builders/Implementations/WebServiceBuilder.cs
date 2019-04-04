﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using TakeRecipeEasily.Infrastructure.Busses;
using TakeRecipeEasily.Infrastructure.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace TakeRecipeEasily.Infrastructure.Builders.Implementations
{
    public class WebServiceBuilder : IWebServiceBuilder
    {
        private readonly IConfiguration _configuration;
        private readonly ContainerBuilder _containerBuilder;

        public WebServiceBuilder(IConfiguration configuration, ContainerBuilder containerBuilder)
        {
            _configuration = configuration;
            _containerBuilder = containerBuilder;
        }

        public static IWebServiceBuilder Create(
            IServiceCollection services,
            IConfiguration configuration,
            Action<ContainerBuilder> builderSteps = null)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterInstance(configuration);
            containerBuilder.Populate(services);

            builderSteps?.Invoke(containerBuilder);
            return new WebServiceBuilder(configuration, containerBuilder);
        }

        public IWebServiceBuilder WithEventsBus()
        {
            _containerBuilder.Register<Func<Type, IEnumerable<IEventHandler>>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IEventHandler<>).MakeGenericType(t);
                    var handlersCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
                    return (IEnumerable<IEventHandler>)ctx.Resolve(handlersCollectionType);
                };
            });

            _containerBuilder.RegisterType<EventsBus>().As<IEventsBus>();
            return this;
        }

        public IWebServiceBuilder WithCommandsBus()
        {
            _containerBuilder.Register<Func<Type, ICommandHandler>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(ICommandHandler<>).MakeGenericType(t);
                    return (ICommandHandler)ctx.Resolve(handlerType);
                };
            });
            _containerBuilder.RegisterType<CommandsBus>().As<ICommandsBus>();
            return this;
        }

        IWebServiceBuilder IWebServiceBuilder.RespondToCommand<TCommand, THandler>()
        {
            _containerBuilder.RegisterType<THandler>().As<ICommandHandler<TCommand>>();
            return this;
        }

        IWebServiceBuilder IWebServiceBuilder.SubscribeToEvent<TEvent, THandler>()
        {
            _containerBuilder.RegisterType<THandler>().As<IEventHandler<TEvent>>();
            return this;
        }

        public IContainer Build()
            => _containerBuilder.Build();
    }
}
