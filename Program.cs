using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using webProjeOdev.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts =>
{
    opts.Cookie.Name = ".webProjeOdev.auth";
    opts.ExpireTimeSpan = TimeSpan.FromDays(7);
    opts.LoginPath="/Giris/AdminLogin";
    opts.LogoutPath = "/Giris/AdminLogout";
    opts.AccessDeniedPath="/Giris/GirisEngelle";
});
builder.Services.AddSession(opt =>
    opt.IdleTimeout = TimeSpan.FromMinutes(25) // 25 dkk icinde girmezse atiyor
); ;//session ekledik


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
app.UseAuthentication();

app.UseAuthorization();
app.UseSession();//session ekledik

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
