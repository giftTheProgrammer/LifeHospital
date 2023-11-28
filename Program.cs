using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LifeHospital.Data;
using LifeHospital.Areas.Identity.Data;
using static System.Formats.Asn1.AsnWriter;

namespace LifeHospital
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthDbContextConnection' not found.");

                                    builder.Services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(connectionString));

                                    builder.Services.AddDefaultIdentity<LifeHospitalUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireUppercase = false;
            });

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
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using ( var scope = app.Services.CreateScope() )
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Doctor", "Nurse", "Patient"};

                foreach ( var role in roles )
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync( new IdentityRole(role) );
                }
            }

            using( var scope = app.Services.CreateScope() )
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<LifeHospitalUser>>();

                string userEmail = "admin@life.hospital";
                string password = "Admin432#";
                string firstName = "Mike";
                string lastName = "Tyson";

                if( await userManager.FindByEmailAsync(userEmail) == null)
                {
                    var user = new LifeHospitalUser();
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.Email = userEmail;
                    user.UserName = userEmail;

                    await userManager.CreateAsync (user, password);

                    await userManager.AddToRoleAsync( user, "Admin" );
                }
            }

            app.Run();
        }
    }
}