using Microsoft.AspNetCore.Mvc;
using product.Repository.Interfaces;

namespace product.Controllers
{
    public class todo : Controller
    {
        private readonly Itodorepository repository;
        public todo(Itodorepository itodorepository)
        {
            repository = itodorepository;
        }
        public async Task<IActionResult> readtodo()
        {
            var result = await repository.readdto();
            return View(result);
        }
    }
}
