using Data.Extensions;
using Repositories.Extensions;
using MySql.Data.MySqlClient;
namespace Web
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);
         builder.Services.AddRepository();
         builder.Services.AddConnectionRepository<MySqlConnection>(builder.Configuration.GetConnectionString("Database"));
         builder.Services.AddDapperFluentMap();

         builder.Services.AddControllersWithViews();
         var app = builder.Build();
         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
         }
         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseRouting();
         app.UseAuthorization();
         app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}");
         app.Run();
      }
   }
}