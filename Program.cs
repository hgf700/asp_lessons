using Microsoft.EntityFrameworkCore;
using aspapp.Models;
using aspapp.Repositories;

namespace aspapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Rejestracja DbContext
            builder.Services.AddDbContext<trip_context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Rejestracja repozytoriów
            builder.Services.AddScoped<ITravelerRepository, TravelerRepository>();
            builder.Services.AddScoped<IGuideRepository, GuideRepository>();
            builder.Services.AddScoped<ITripRepository, TripRepository>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
