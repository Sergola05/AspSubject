namespace Kt3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
              name: "text",
              pattern: "Test/Text",
              defaults: new { controller = "Test", action = "Text" });

            app.MapControllerRoute(
                name: "html",
                pattern: "Test/Html",
                defaults: new { controller = "Test", action = "Html" });

            app.MapControllerRoute(
                name: "json",
                pattern: "Test/Json",
                defaults: new { controller = "Test", action = "Json" });

            app.MapControllerRoute(
                name: "file",
                pattern: "Test/File",
                defaults: new { controller = "Test", action = "File" });

            app.MapControllerRoute(
                name: "status",
                pattern: "Test/Status",
                defaults: new { controller = "Test", action = "Status" });

            app.MapControllerRoute(
                name: "cookie",
                pattern: "Test/Cookie",
                defaults: new { controller = "Test", action = "Cookie" });

            app.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
