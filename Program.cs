using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Flights.Data;
using Microsoft.AspNetCore.Identity;
using Flights.Models;
namespace Flights
{
    public class Program
    {
        //promqna - trqbwa da e async Task, a ne void
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<FlightsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FlightsContext") ?? throw new InvalidOperationException("Connection string 'FlightsContext' not found.")));

            //promqna
            builder.Services.AddDbContext<PersonContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PersonContextConnection")));
            //promqna za requreConformedAccount + roles
            builder.Services.AddDefaultIdentity<Person>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<PersonContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //promqna
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //promqna
            app.MapRazorPages();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            //promqna
            using (var scope = app.Services.CreateScope())
            {
                //suzdava novi roli kato proverqva dali veche ne sushtestvuvat
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "admin", "employee", "user" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            app.Run();
        }
    }
}
