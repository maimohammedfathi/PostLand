using PostLandAPI.Extentions;

namespace PostLandAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddUnitOfWorkRepository();
            builder.Services.AddDbConfig(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowCors",
            //        builder =>
            //        {
            //            builder
            //            .AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .WithOrigins("http://localhost:3000")
            //            .SetIsOriginAllowed((host) => true)
            //            .AllowCredentials();
            //        });
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.ApplyAutoMigration();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}