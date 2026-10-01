using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> PostBlog()
        {
            return NotFound();
        }
    }
}
