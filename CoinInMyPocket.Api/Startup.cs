using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoinInMyPocket.Core.Repositories;
using CoinInMyPocket.Infrastructure.Authentication.Middleware;
using CoinInMyPocket.Infrastructure.Builders.Implementations;
using CoinInMyPocket.Infrastructure.Handlers;
using CoinInMyPocket.Infrastructure.IoC;
using CoinInMyPocket.Infrastructure.Contracts.Commands;
using CoinInMyPocket.Infrastructure.Repositories;
using CoinInMyPocket.Infrastructure.Services;
using CoinInMyPocket.Infrastructure.Services.Implementations;
using CoinInMyPocket.Infrastructure.Settings;
using CoinInMyPocket.Infrastructure.SQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CoinInMyPocket.Infrastructure.Exceptions;

namespace CoinInMyPocket.Api
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
            services.AddDbContext<CoinInMyPocketContext>(options => options.UseSqlServer(sqlSettings.ConnectionString));

            var applicationContainer = MVCWebServiceBuilder
                .Create(services, Configuration, builder =>
                {
                    builder.RegisterInstance(Configuration.GetSettings<AuthSettings>());
                    builder.RegisterInstance(sqlSettings);

                    builder.RegisterRepository<UsersRepository, IUsersRepository>();

                    builder.RegisterService<AuthenticationService, IAuthenticationService>();
                    builder.RegisterService<PasswordHasher, IPasswordHasher>();
                    builder.RegisterService<UsersService, IUsersService>();

                    builder.RegisterType<HmacJwtService>().As<IJwtService>();
                })
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

            app.UseCoinInMyPocketExceptions();
            app.UseJwtAuthentication();
            app.UseMvc();
        }
    }
}
