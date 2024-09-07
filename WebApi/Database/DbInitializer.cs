using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;
using WebApi.Database.Entities;

namespace WebApi.Database
{
    public static class DbInitializer
    {
        // Add any initials here.
        public static async Task InitializeAsync(PersonFinderDbContext ctx)
        {
            DateTime dtNow = DateTime.Now;
            UserProfile currentUser = null;

            if (!await (from u in ctx.UserProfiles select u.Id).AnyAsync())
            {
                currentUser = new UserProfile
                {
                    Login = "TestLogin",
                    CreatedDate = dtNow,
                    ContactEmail = "test@gmail.com",
                };

                ctx.UserProfiles.Add(currentUser);
                await ctx.SaveChangesAsync();
            }

            if (!await (from c in ctx.Cards select c.Id).AnyAsync())
            {
                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToTeach,
                    AbilityKeyWords = "driver",
                    LocationChoice = LocationType.Specified,
                    Country = "Germany",
                    Region = "Berlin",
                    LanguageChoice = 4,
                    AgeChoice = 1,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddYears(1),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToBeInterested,
                    AbilityKeyWords = "voleyball; beach voleyball",
                    LocationChoice = LocationType.Specified,
                    Country = "Georgia",
                    Region = "Batumi",
                    LanguageChoice = 2,
                    AgeChoice = 1,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddYears(2),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToBeInterested,
                    AbilityKeyWords = "football;soccer",
                    LocationChoice = LocationType.Anywhere,
                    Country = "",
                    Region = "",
                    LanguageChoice = 3,
                    AgeChoice = 2,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddYears(1),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToBeInterested,
                    AbilityKeyWords = "programming;Java;JavaScript",
                    LocationChoice = LocationType.Specified,
                    Country = "UK",
                    Region = "London",
                    LanguageChoice = 1,
                    AgeChoice = 3,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddMonths(3),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToLearn,
                    AbilityKeyWords = "English",
                    LocationChoice = LocationType.Specified,
                    Country = "France",
                    Region = "Monaco",
                    LanguageChoice = 5,
                    AgeChoice = 2,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddMonths(1),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToLearn,
                    AbilityKeyWords = "MSSQL;database;SQL",
                    LocationChoice = LocationType.Anywhere,
                    Country = "",
                    Region = "",
                    LanguageChoice = 1,
                    AgeChoice = 1,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddMonths(2),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToBeInterested,
                    AbilityKeyWords = "football; soccer",
                    LocationChoice = LocationType.Specified,
                    Country = "Georgia",
                    Region = "Tbilissi",
                    LanguageChoice = 4,
                    AgeChoice = 1,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddYears(2),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToTeach,
                    AbilityKeyWords = "Swimming",
                    LocationChoice = LocationType.Specified,
                    Country = "Bulgaria",
                    Region = "Sofia",
                    LanguageChoice = 1,
                    AgeChoice = 1,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddMonths(6),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToTeach,
                    AbilityKeyWords = "math",
                    LocationChoice = LocationType.Anywhere,
                    Country = "",
                    Region = "",
                    LanguageChoice = 1,
                    AgeChoice = 1,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddMonths(6),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToLearn,
                    AbilityKeyWords = "web;programming;css;",
                    LocationChoice = LocationType.Anywhere,
                    Country = "",
                    Region = "",
                    LanguageChoice = 1,
                    AgeChoice = 3,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddMonths(3),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToBeInterested,
                    AbilityKeyWords = "politics",
                    LocationChoice = LocationType.Anywhere,
                    Country = "",
                    Region = "",
                    LanguageChoice = 5,
                    AgeChoice = 4,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddYears(3),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();

                ctx.Cards.Add(new Card
                {
                    AbilityChoice = SearchType.ToBeInterested,
                    AbilityKeyWords = "chess",
                    LocationChoice = LocationType.Anywhere,
                    Country = "",
                    Region = "",
                    LanguageChoice = 1,
                    AgeChoice = 2,
                    IsActive = true,
                    CreatedDate = dtNow,
                    ExpirationDate = dtNow.AddYears(2),
                    OwnerId = currentUser.Id
                });
                await ctx.SaveChangesAsync();
            }
        }
    }
}