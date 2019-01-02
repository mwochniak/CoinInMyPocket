using Autofac;
using Autofac.Extensions.DependencyInjection;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Infrastructure.Authentication.Middleware;
using TakeRecipeEasily.Infrastructure.Builders.Implementations;
using TakeRecipeEasily.Infrastructure.Handlers;
using TakeRecipeEasily.Infrastructure.IoC;
using TakeRecipeEasily.Infrastructure.Repositories;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Services.Implementations;
using TakeRecipeEasily.Infrastructure.Settings;
using TakeRecipeEasily.Infrastructure.SQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TakeRecipeEasily.Infrastructure.Exceptions;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Users;
using TakeRecipeEasily.Infrastructure.Handlers.Users;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Auth;
using TakeRecipeEasily.Infrastructure.Handlers.Auth;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Handlers.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Authentication.Settings;

namespace TakeRecipeEasily.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            services.AddOptions();
            services.AddSingleton(Configuration);
            var sqlSettings = Configuration.GetSettings<SQLSettings>();
            services.AddDbContext<TakeRecipeEasilyContext>(options => options.UseSqlServer(sqlSettings.ConnectionString));

            var applicationContainer = MVCWebServiceBuilder
                .Create(services, Configuration, builder =>
                {
                    builder.RegisterInstance(Configuration.GetSettings<AuthSettings>());
                    builder.RegisterInstance(sqlSettings);

                    builder.RegisterRepository<IngredientsCategoriesRepository, IIngredientsCategoriesRepository>();
                    builder.RegisterRepository<UsersRepository, IUsersRepository>();

                    builder.RegisterService<AuthenticationService, IAuthenticationService>();
                    builder.RegisterService<IngredientsCategoriesService, IIngredientsCategoriesService>();
                    builder.RegisterService<PasswordHasher, IPasswordHasher>();
                    builder.RegisterService<UsersService, IUsersService>();

                    builder.RegisterType<HmacJwtService>().As<IJwtService>();
                    builder.RegisterType<Handler>().As<IHandler>();
                })
                .RespondToCommand<CreateIngredientCategoryCommand, CreateIngredientCategoryCommandHandler>()
                .RespondToCommand<CreateUserCommand, CreateUserCommandHandler>()
                .RespondToCommand<LoginCommand, LoginCommandHandler>()
                .WithCommandsBus()
                .WithEventsBus()
                .Build();

            return new AutofacServiceProvider(applicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseTakeRecipeEasilyExceptions();
            app.UseJwtAuthentication();
            app.UseMvc();
        }
    }
}
