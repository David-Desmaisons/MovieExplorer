using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MovieExplorerApi.Site
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCorsForApplication(this IServiceCollection services, IHostingEnvironment env, IConfiguration configuration)
        {
            return services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                var withOrigin = env.IsDevelopment()
                    ? builder.AllowAnyOrigin()
                    : builder.WithOrigins(configuration["ApiSite"]);

                withOrigin.AllowAnyMethod().AllowAnyHeader();
            }));
        }
    }
}
