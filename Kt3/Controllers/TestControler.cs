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
        public IActionResult Html()
        {
            string htmlContent = "<h1>Hello, World!</h1><p>This is a test HTML page.</p>";
            HttpContext.Response.ContentType = "text/html";
            return new ContentResult { Content = htmlContent };
        }
    }
}
