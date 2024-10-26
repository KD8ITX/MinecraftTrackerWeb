using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MinecraftTrackerObjects;

namespace MinecraftTrackerWeb.Controllers
{
    [Route("MapPoint")]
    public class MapPointController : Controller
    {
        private readonly MinecraftTrackerAppClient _mapPointService;
        private readonly AppSettings _appSettings;

        public MapPointController(MinecraftTrackerAppClient mapPointService, IOptions<AppSettings> appSettings)
        {
            _mapPointService = mapPointService;
            _appSettings = appSettings.Value;

            _mapPointService.SetUrl(_appSettings.BaseUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // By default, it will look for the view in /Views/MapPoint/Index.cshtml
            List<MapPoint> points = await _mapPointService.GetAllMapPointsAsync();
            
            return View("Index", points);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        // POST: MapPointController/Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(MapPoint point)
        {

            bool isPosted = await _mapPointService.PostMapPointAsync(point);

            if (isPosted)
            {
                return RedirectToAction("Index", "MapPoint");
            }
            else
            {
                return RedirectToAction("Index", "MapPoint");
            }
        }

        
    }
}
