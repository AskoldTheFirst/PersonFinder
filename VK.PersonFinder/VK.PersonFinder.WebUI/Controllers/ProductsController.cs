using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using VK.PersonFinder.WebUI.Models;

namespace VK.PersonFinder.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Route(template: "List")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public List<Product> GetProducts()
        {
            var desk = new Product() { Name = "Desk", Price = 100 };
            var chair = new Product() { Name = "Chair", Price = 20 };

            return new List<Product>() { desk, chair };
        }
    }
}
