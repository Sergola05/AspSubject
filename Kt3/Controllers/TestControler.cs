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
        public IActionResult Json()
        {
            var data = new { Name = "John", Age = 30 };
            HttpContext.Response.ContentType = "application/json";
            return new JsonResult(data);
        }
        public async Task<IActionResult> File()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
            await System.IO.File.WriteAllTextAsync(filePath, "This is a test file");

            HttpContext.Response.ContentType = "text/plain";
            HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=test.txt");
            await HttpContext.Response.SendFileAsync(filePath);

            return new EmptyResult();
        }
        public IActionResult Status()
        {
            HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            return new ContentResult { Content = "Page not found", ContentType = "text/plain" };
        }
        public IActionResult Cookie()
        {
            HttpContext.Response.Cookies.Append("user", "Answer");
            return new ContentResult { Content = "Cookie 'user' has been set to 'Answer'", ContentType = "text/plain" };
        }
    }
}
