using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PickleLeaugev4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> test()
        {
            return Ok("Test");
        }
    }
}
