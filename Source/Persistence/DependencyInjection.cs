using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobContext>(options => 
                options.UseMySQL(configuration.GetConnectionString("JobHuntDB")));

            services.AddScoped<IJobContext>(provider => provider.GetService<JobContext>());

            return services;
        }
    }
}
