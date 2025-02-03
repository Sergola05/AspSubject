using Microsoft.AspNetCore.Mvc;

namespace Kt3.Controllers
{
    public class EchoController : Controller
    {
        [HttpGet]
        public async Task Get()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("GET request received");
        }

        [HttpPost]
        public async Task Post()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("POST request received");
        }

        [HttpGet]
        public async Task Headers()
        {
            var headers = Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());
            Response.ContentType = "application/json";
            await Response.WriteAsJsonAsync(headers);
        }

        [HttpGet]
        public async Task Query()
        {
            var queryParams = Request.Query.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());
            Response.ContentType = "application/json";
            await Response.WriteAsJsonAsync(queryParams);
        }

        [HttpPost]
        public async Task Body()
        {
            using var reader = new StreamReader(Request.Body);
            var body = await reader.ReadToEndAsync();
            Response.ContentType = "text/plain";
            await Response.WriteAsync(body);


        }
    }
}
