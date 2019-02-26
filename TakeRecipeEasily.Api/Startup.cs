using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TakeRecipeEasily.Infrastructure.Authentication.Middleware;
using TakeRecipeEasily.Infrastructure.Authentication.Settings;
using TakeRecipeEasily.Infrastructure.Builders.Implementations;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Auth;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Ingredients;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Recipes;
using TakeRecipeEasily.Infrastructure.Contracts.Commands.Users;
using TakeRecipeEasily.Infrastructure.Exceptions;
using TakeRecipeEasily.Infrastructure.Handlers;
using TakeRecipeEasily.Infrastructure.Handlers.Auth;
using TakeRecipeEasily.Infrastructure.Handlers.Ingredients;
using TakeRecipeEasily.Infrastructure.Handlers.IngredientsCategories;
using TakeRecipeEasily.Infrastructure.Handlers.Recipes;
using TakeRecipeEasily.Infrastructure.Handlers.Users;
using TakeRecipeEasily.Infrastructure.IoC;
using TakeRecipeEasily.Infrastructure.Services;
using TakeRecipeEasily.Infrastructure.Services.Implementations;
using TakeRecipeEasily.Infrastructure.Settings;
using TakeRecipeEasily.Infrastructure.SQL;

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
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetSettings<DatabaseSettings>().ConnectionString));

            var applicationContainer = MVCWebServiceBuilder
                .Create(services, Configuration, builder =>
                {
                    builder.RegisterInstance(Configuration.GetSettings<AuthSettings>()).SingleInstance();

                    builder.RegisterService<AuthenticationService, IAuthenticationService>();
                    builder.RegisterService<PasswordHasher, IPasswordHasher>();

                    builder.RegisterService<IngredientsCategoriesCommandService, IIngredientsCategoriesCommandService>();
                    builder.RegisterService<IngredientsCategoriesQueryService, IIngredientsCategoriesQueryService>();
                    builder.RegisterService<IngredientsCommandService, IIngredientsCommandService>();
                    builder.RegisterService<IngredientsQueryService, IIngredientsQueryService>();
                    builder.RegisterService<RecipesCommandService, IRecipesCommandService>();
                    builder.RegisterService<RecipesQueryService, IRecipesQueryService>();
                    builder.RegisterService<UsersCommandService, IUsersCommandService>();
                    builder.RegisterService<UsersQueryService, IUsersQueryService>();

                    builder.RegisterType<HmacJwtService>().As<IJwtService>();
                    builder.RegisterType<Handler>().As<IHandler>();
                })
                .RespondToCommand<CreateIngredientCategoryCommand, CreateIngredientCategoryCommandHandler>()
                .RespondToCommand<CreateIngredientCommand, CreateIngredientCommandHandler>()
                .RespondToCommand<CreateRecipeCommand, CreateRecipeCommandHandler>()
                .RespondToCommand<CreateUserCommand, CreateUserCommandHandler>()
                .RespondToCommand<DeleteRecipeCommand, DeleteRecipeCommandHandler>()
                .RespondToCommand<LoginCommand, LoginCommandHandler>()
                .RespondToCommand<UpdateIngredientCommand, UpdateIngredientCommandHandler>()
                .RespondToCommand<UpdateRecipeCommand, UpdateRecipeCommandHandler>()
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
                app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            }

            app.UseTakeRecipeEasilyExceptions();
            app.UseJwtAuthentication();
            app.UseMvc();
        }
    }
}
