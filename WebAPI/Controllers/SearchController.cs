using BL.DTOs.UtilityDTOs;
using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchFacade _searchFacade;

        public SearchController(ISearchFacade searchFacade)
        {
            _searchFacade = searchFacade;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            var res = await _searchFacade.QuerySearch(query, SearchMode.Or);

            return Ok(res);
        }
    }
}
