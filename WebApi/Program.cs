
using WebApi.Database;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // To create initial db.
            {
                var client = new MongoClient("mongodb://localhost:27017/");
                IMongoDatabase database = client.GetDatabase("PersonFinderDb");
                PersonFinderDbContext.Create(database);
            }

            app.Run();
        }
    }
}
