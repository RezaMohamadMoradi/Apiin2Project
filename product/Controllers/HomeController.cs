using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using product.Models;
using product.Repository;
using product.Repository.Interfaces;
using System.Diagnostics;

namespace product.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly icategory _categoryrepository;

        public HomeController(ILogger<HomeController> logger, icategory categoryrepository)
        {
            _logger = logger;
            _categoryrepository = categoryrepository; // «’·«Õ ‘œÂ
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> showcategory()
        {
            var result = await _categoryrepository.Getallcatshow();
            if (result.issucses == true)
            {
                var cat = JsonConvert.DeserializeObject<List<CategoryesDto>>(Convert.ToString(result.data));
                return View(cat);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
