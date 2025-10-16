using Microsoft.AspNetCore.Mvc;

namespace MusicComplexApi.Controllers
{
    [ApiController]
    [Route("success")]
    public class SuccessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Authentication successful! You can close this page.");
        }
    }
}