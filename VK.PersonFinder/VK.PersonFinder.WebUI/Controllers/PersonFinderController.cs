using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VK.PersonFinder.WebUI.Models;

namespace VK.PersonFinder.WebUI.Controllers
{
    public class PersonFinderController : Controller
    {
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            return View();
        }

        //[Authorize]
        public IActionResult Add()
        {
            return View();
        }

        //[Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
