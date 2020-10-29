using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using TeachMeSkills.Web.ViewModels;

namespace TeachMeSkills.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public HomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 300)]
        public IActionResult Secret(int id, [FromQuery] string query, [FromBody] SecretViewModel secret, [FromHeader] string secretValue)
        {
            if (!_memoryCache.TryGetValue(id, out string str))
            {
                str = $"Route: {id}, Query: {query}, Body: {secret.Key}, Header: {secretValue}";
                _memoryCache.Set(
                    id,
                    str,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(10)));
            }

            return Content(str);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
