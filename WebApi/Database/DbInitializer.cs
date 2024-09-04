using Microsoft.EntityFrameworkCore;
using WebApi.Database.Entities;

namespace WebApi.Database
{
    public static class DbInitializer
    {
        // Add any initials here.
        public static async Task InitializeAsync(PersonFinderDbContext ctx)
        {
            DateTime dtNow = DateTime.Now;

            if (!await (from u in ctx.UserProfiles select u.Id).AnyAsync())
            {
                List<UserProfile> testUsers = new();

                testUsers.Add(new UserProfile()
                {
                    Login = "TestLogin",
                    CreatedDate = dtNow,
                    ContactEmail = "test@gmail.com",
                    Id = 1
                });

                ctx.UserProfiles.AddRange(testUsers);
                await ctx.SaveChangesAsync();
            }

            if (!await (from c in ctx.Cards select c.Id).AnyAsync())
            {
                List<Card> testCards = new();

                ctx.Cards.Add(new Card()
                {
                    Id = 1,
                    AbilityChoice = 1,
                    AbilityKeyWords = ["driver"],
                    LocationChoice = 2,
                    Country = "Germany",
                    Region = "Berlin",
                    LanguageChoice = 4,
                    AgeChoice = 1,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddYears(1),
                    OwnerId = 1
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card()
                {
                    Id = 2,
                    AbilityChoice = 3,
                    AbilityKeyWords = ["voleyball", "beach voleyball"],
                    LocationChoice = 2,
                    Country = "Georgia",
                    Region = "Batumi",
                    LanguageChoice = 2,
                    AgeChoice = 1,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddYears(2),
                    OwnerId = 1
                });
                await ctx.SaveChangesAsync();
            }
        }
    }
}