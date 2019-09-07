using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieExplorerApi.Services;
using MovieExplorerApi.Site.Infra;

namespace MovieExplorerApi.Site
{
    public class Startup
    {
        private readonly IHostingEnvironment _Environment;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<ITheMovieDatabaseClient,TheMovieDatabaseClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["TheMovieDatabase:url"]);
            });

            services.AddCorsForApplication(_Environment, Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Movie Explorer API" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "Movie Explorer API");
                c.RoutePrefix = "";
            });
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = ExceptionHandler.Handle
            });

            app.UseMvc();
        }
    }
}
