using Microsoft.EntityFrameworkCore;
using WebApi.Database.Entities;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoDB.EntityFrameworkCore.Extensions;


namespace WebApi.Database
{
    public class PersonFinderDbContext : DbContext
    {
        public PersonFinderDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>().ToCollection("cards");
            modelBuilder.Entity<UserProfile>().ToCollection("userProfiles");
            modelBuilder.Entity<Message>().ToCollection("messages");
        }

        public DbSet<Card> Cards { get; init; }

        public DbSet<UserProfile> UserProfiles { get; init; }

        public DbSet<Message> Messages { get; init; }

        public static PersonFinderDbContext Create(IMongoDatabase database) {

            var newDb = new PersonFinderDbContext(new DbContextOptionsBuilder<PersonFinderDbContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                .Options);
            
            newDb.Database.EnsureCreated();

            return newDb;
        }
    }
}
