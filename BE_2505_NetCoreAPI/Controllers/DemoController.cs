using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_2505_NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpPost("GetListStudent")]
        public async Task<ActionResult> GetListStudent()
        {
            return Ok(new { message = "GetList" });
        }
    }
}
