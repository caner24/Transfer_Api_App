using Microsoft.AspNetCore.Mvc;

namespace Transfer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : Controller
    {

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
