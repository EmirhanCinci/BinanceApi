using BinanceApi.Service;
using Microsoft.AspNetCore.SignalR;

namespace BinanceApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddDbContext<BinanceDbContext>();
            builder.Services.AddScoped<BinanceService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:59091").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });

            builder.Services.AddSignalR();

            //var dbContext = new BinanceDbContext(); 
            //var binanceService = new BinanceService(dbContext);
            //var continuousDataFetcher = new ContinuousDataFetcher(binanceService);
            //// continuousDataFetcher.Stop(); // Görevi durdurmak için
            //continuousDataFetcher.Stop();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapHub<HubService>("/HubService");
            app.Run();
        }
    }
}