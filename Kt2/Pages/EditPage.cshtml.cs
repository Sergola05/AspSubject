using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace Kt2.Pages
{
    public class EditPageModel : PageModel
    {
        [BindProperty]
        public string Content { get; set; }

        public void OnGet()
        {
            Content = "<p>Your existing content here.</p>";
        }

        public async Task<IActionResult> OnPostUploadImage()
        {
            var file = Request.Form.Files[0];
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imageUrl = $"/uploads/{file.FileName}";
            return new JsonResult(new { url = imageUrl });
        }
    }
}