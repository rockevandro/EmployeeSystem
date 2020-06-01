using EmployeeSystem.Domain.RepositoryInterfaces;
using EmployeeSystem.Infra;
using EmployeeSystem.Infra.Data;
using EmployeeSystem.Infra.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Reflection;

namespace EmployeeSystem.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Development"));
            });

            services.AddControllers()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            services.TryAddTransient<IEmployeeRepository, EmployeeRepository>();
            services.TryAddTransient<ISkillRepository, SkillRepository>();
            services.TryAddTransient<IGenderRepository, GenderRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            var cultureInfoBr = new CultureInfo("pt-BR");
            var supportedCultures = new[]
            {
                cultureInfoBr,
            };

            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = null
            };

            app.UseRequestLocalization(requestLocalizationOptions);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            var databaseContext = serviceProvider.GetRequiredService<DatabaseContext>();
            databaseContext.Database.Migrate();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
