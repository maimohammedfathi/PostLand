using Microsoft.EntityFrameworkCore;
using PostLandApplication;
using PostLandApplication.Interfaces;
using PostLandInfrastructure.Context;
using PostLandInfrastructure.Repositories;
using System.Runtime.CompilerServices;

namespace PostLandAPI.Extentions
{
    public static class ServicesExtentions
    {
        public static void AddUnitOfWorkRepository(this IServiceCollection service)
        {
            service.AddScoped(typeof(IGRepository<>), typeof(BaseRepository<>));
            service.AddScoped<IPostRepository, PostRepository>();
            service.AddAutoMapper(typeof(ApplicationLayer));
            service.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(ApplicationLayer)));
            service.AddHttpContextAccessor();
            service.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void AddDbConfig(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<PostDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PostConnection"));
                options.LogTo(Console.WriteLine, LogLevel.Information);
                options.EnableSensitiveDataLogging(true);   
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        //public static void AddCorsConfig(this IServiceCollection service) 
        //{
        //    service.AddCors(options =>
        //    {
        //        options.AddPolicy("AllowCors",
        //            builder =>
        //            {
        //                builder
        //                .AllowAnyHeader()
        //                .AllowAnyMethod()
        //                .WithOrigins("http://localhost:3000")
        //                .AllowAnyOrigin()
        //                .SetIsOriginAllowed((host) => true)
        //                .AllowCredentials();

        //            });
        //    });
        //}

        //public static void ApplyAutoMigration(this WebApplication app)
        //{
        //    using (var serviceScope = app.Services.CreateScope())
        //    {
        //        var DbContext = serviceScope.ServiceProvider.GetRequiredService<PostDbContext>();
        //        var serviceProvider = serviceScope.ServiceProvider;
        //        if (!serviceScope.ServiceProvider.GetService<PostDbContext>().AllMigrationApplied())
        //        {
        //            serviceScope.ServiceProvider.GetService<PostDbContext>().Migrate();
        //        }
        //    }
        //}


    }
}
