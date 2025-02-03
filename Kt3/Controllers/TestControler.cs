using Microsoft.AspNetCore.Mvc;

namespace Kt3.Controllers
{
    public class TestControler : Controller
    {
        public IActionResult Text()
        {
            HttpContext.Response.ContentType = "text/plain";
            return new ContentResult { Content = "Hello, world!" };
        }
    }
}
