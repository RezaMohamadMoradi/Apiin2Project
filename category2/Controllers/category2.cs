using Category2.Services.IServices;
using Category2.Models;
using Microsoft.AspNetCore.Mvc;

namespace category2.Controllers
{
    public class category2 : basecontroller
    {
        private readonly IBaseServices _baseServices;

        public category2(IBaseServices baseServices)
        {
            _baseServices = baseServices;
        }

        [HttpGet("readall")]
        public async Task<IActionResult> readallcat()
        {
            var result = await _baseServices.readallcat();
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> createcate(Categoryes cat)
        {
            //Categoryes categoryes = new Categoryes();
            //categoryes.name = cat.name;
            var result = await _baseServices.createcat(cat);
            return Ok(result);
        }
       
    }
}
