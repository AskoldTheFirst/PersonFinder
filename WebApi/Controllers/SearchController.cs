using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Database;
using WebApi.Database.Entities;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    public class SearchController : BaseApiController
    {
        private readonly ILogger<SearchController> _logger;

        private readonly PersonFinderDbContext _ctx;

        public SearchController(PersonFinderDbContext context, ILogger<SearchController> logger)
        {
            _ctx = context;
            _logger = logger;
        }

        [HttpGet("exact-search")]
        public async Task<ActionResult<SearchResultDto[]>> SearchAsync([FromQuery] SearchParamsDto searchParams)
        {
            SearchParamsDto sp = searchParams;
            string[] keyWords = sp.AbilityKeyWords.Split(';');
            DateTime dtNow = DateTime.Now;

            Card[] matchedCards = await (from c in _ctx.Cards
                                         where c.IsActive
                                                && c.AbilityChoice == sp.AbilityChoice
                                                //&& Contains(c.AbilityKeyWords, keyWords)
                                                && c.LanguageChoice == sp.LanguageChoice
                                                && c.LocationChoice == sp.LocationChoice
                                                && c.Country == sp.LocationCountry
                                                && c.Region == sp.LocationRegion
                                                && c.AgeChoice == sp.AgeChoice
                                                && c.ExpirationDate > dtNow
                                         select c).ToArrayAsync();

            SearchResultDto[] results = new SearchResultDto[matchedCards.Length];
            for(int i = 0 ; i < matchedCards.Length; ++i)
            {
                results[i] = new SearchResultDto();
                results[i].CardId = matchedCards[i].Id;
                results[i].Login = await (from u in _ctx.UserProfiles
                                            where u.Id == matchedCards[i].OwnerId
                                            select  u.Login).SingleAsync();
            }

            return results;
        }

        private static bool Contains(string[] firstArray, string[] secondArray)
        {
            for (int i = 0; i < firstArray.Length; ++i)
            {
                for (int j = 0; j < secondArray.Length; ++j)
                {
                    if (string.Compare(firstArray[i], secondArray[j]) == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
