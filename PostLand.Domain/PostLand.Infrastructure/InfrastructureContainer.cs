using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostLandApplication.Interfaces;
using PostLandInfrastructure.Context;
using PostLandInfrastructure.Repositories;

namespace PostLandInfrastructure
{
    public static class InfrastructureContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);
            ConfigureRepositories(services);

            return services;
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PostConnection")));
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IGRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
        }
    }
}
