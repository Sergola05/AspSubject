using Microsoft.AspNetCore.Mvc;

namespace Kt3.Controllers
{
    public class TestControler : Controller
    {
        public async Task Text()
        {
            HttpContext.Response.ContentType = "text/plain";
            await HttpContext.Response.WriteAsync("Hello, world!");
        }

        public async Task Html()
        {
            HttpContext.Response.ContentType = "text/html";
            await HttpContext.Response.WriteAsync("<h1>Hello</h1><p>World!</p>");
        }

        public async Task Json()
        {
            HttpContext.Response.ContentType = "application/json";
            var data = new { Name = "Maxime", Age = 20 };
            await HttpContext.Response.WriteAsJsonAsync(data);
        }

        public async Task File()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
            HttpContext.Response.ContentType = "text/plain";
            await HttpContext.Response.SendFileAsync(filePath);
        }

        public async Task Status()
        {
            HttpContext.Response.StatusCode = 404;
            await HttpContext.Response.WriteAsync("Not Found");
        }

        public async Task Cookie()
        {
            HttpContext.Response.Cookies.Append("user", "Answer");
            await HttpContext.Response.WriteAsync("Cookie set successfully.");
        }
    }
}
