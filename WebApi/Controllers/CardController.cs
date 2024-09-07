using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.Database;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    public class CardController : BaseApiController
    {
        private readonly ILogger<CardController> _logger;

        private readonly PersonFinderDbContext _ctx;

        public CardController(PersonFinderDbContext context, ILogger<CardController> logger)
        {
            _logger = logger;
            _ctx = context;
        }

        [HttpGet("cards")]
        public async Task<ActionResult<CardDto[]>> CardsAsync()
        {
            CardDto[] cards = await (from c in _ctx.Cards
                                     select new CardDto
                                     {
                                        AbilityChoice = c.AbilityChoice,
                                        AbilityKeyWords = c.AbilityKeyWords,
                                        AgeChoice = c.AgeChoice,
                                        CreatedDate = c.CreatedDate,
                                        ExpirationDate = c.ExpirationDate,
                                        IsActive = c.IsActive,
                                        LanguageChoice = c.LanguageChoice,
                                        LocationChoice = c.LocationChoice,
                                        LocationCountry = c.Country,
                                        LocationRegion = c.Region,
                                        OwnerLogin = c.OwnerLogin,
                                        //CardId = c.Id,
                                        //OwnerId = c.OwnerId
                                     }).ToArrayAsync();

            return cards;
        }

        [HttpGet("total")]
        public async Task<ActionResult<int>> TotalAsync()
        {
            return await (from c in _ctx.Cards
                          where c.IsActive && c.ExpirationDate > DateTime.Now
                          select c.Id).CountAsync();
        }
    }
}