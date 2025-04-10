using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Models;
using NewsApi.Services;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsService _newsService;

        public NewsController(NewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("vowelcount")]
        public async Task<IActionResult> GetVowelCount(string keyword, string section, string language)
        {
            var news = await _newsService.GetNewsAsync(keyword, language);

            var results = news.Select(article => new NewsVowelCount
            {
                Section = section,
                VowelCount = article.CountVowels(section)
            }).OrderByDescending(r => r.VowelCount).ToList();

            return Ok(results);
        }

        
    }
}
