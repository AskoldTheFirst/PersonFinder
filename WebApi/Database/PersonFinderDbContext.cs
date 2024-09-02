using Microsoft.EntityFrameworkCore;

namespace WebApi.Database
{
    public class PersonFinderDbContext : DbContext
    {
        public PersonFinderDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
