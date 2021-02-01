using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonalFinanceManagement.Extensions;
using PersonalFinanceManagement.Infrastructure.Database;
using PersonalFinanceManagement.Infrastructure.Notifications;
using PersonalFinanceManagement.Infrastructure.Repositories;
using PersonalFinanceManagement.Middleware;

namespace PersonalFinanceManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<PersonalFinanceManagementContext>(options=>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                     e=>e.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name)));

            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(Application.CommandHandlers.ReportingPeriodHandler).Assembly);

            services.AddScoped<IEventDispatcher, MediatoREventDispatcher>();
            services.AddRepositories(typeof(PersonalFinanceManagement.Infrastructure.Repositories.UnitOfWork).Assembly);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            // app.UseRouting();

            // app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });

            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            app
                .UseValidationExceptionHandler()
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapControllers());
        }
    }
}
