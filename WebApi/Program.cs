
using WebApi.Database;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<PersonFinderDbContext>(opt =>
            {
                opt.UseMongoDB("mongodb://localhost:27017/", "PersonFinderDb");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(new[] { "http://localhost:5003", "http://127.0.0.1:5003" });
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PersonFinderDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                var client = new MongoClient("mongodb://localhost:27017/");
                IMongoDatabase database = client.GetDatabase("PersonFinderDb");
                PersonFinderDbContext.Create(database);
                await DbInitializer.InitializeAsync(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "A problem occurred during migrations.");
            }

            app.Run();
        }
    }
}
