using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.BusinessLayer;
using SchoolManagement.DataAccessLayer;
using SchoolManagement.DataAccessLayer.Models;
using SchoolManagement.ExceptionHandling;

namespace SchoolManagement.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;

            builder.Services.AddScoped<IBusiness, Business>();
            builder.Services.AddScoped<IDataAccess, DataAccess>();
            builder.Services.AddSingleton<ExceptionHandler>();
            builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDBConnectionString")));

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
                name: "default",
                pattern: "{controller=Home}/{action=StudentList}/{id?}");

            app.Run();
        }
    }
}
