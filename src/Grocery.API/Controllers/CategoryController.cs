using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Grocery.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok("It works!!");
        }
    }
}
