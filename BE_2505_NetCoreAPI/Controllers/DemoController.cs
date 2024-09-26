using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_2505_NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("GetListStudent")]
        public async Task<ActionResult> GetListStudent()
        {
            Task.Yield();
			var list = new List<Student>();
            try
            {
               
                for(int i = 0; i < 10; i++)
                {
					list.Add(new Student
                    {
						Id = i,
						Name = $"Student {i}",
						Address =$"Address {i}", 
					});
				}
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(list);
        }
    }
}
