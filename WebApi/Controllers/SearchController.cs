using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet("search")]
        public ActionResult<SearchResultDto> Search([FromBody] SearchParamsDto searchParams)
        {
            return new SearchResultDto();
        }
    }
}
