using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillProfi.Auth;
using SkillProfi.Data;
using SkillProfi.DataContext;
using SkillProfi.Interfaces;

var builder = WebApplication.CreateBuilder(args);


string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppealDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddTransient<IAppealsData, AppealsData>();


builder.Services.AddMvc(mvcOptions => mvcOptions.EnableEndpointRouting = false);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.LoginPath = "/api/Login";
        o.LogoutPath = "/api/Logout";
    });

builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppealDbContext>()
            .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 2; // минимальное количество знаков в пароле
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;


    options.Lockout.MaxFailedAccessAttempts = 10; // количество попыток о блокировки
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.AllowedForNewUsers = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // конфигурация Cookie с целью использования их для хранения авторизации
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.SlidingExpiration = true;
});
// Add services to the container.

var app = builder.Build();
app.UseStaticFiles();

app.UseAuthentication();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=home}/{action=index}/{id?}");
});

app.Run();
