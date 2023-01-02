using Hastane.Business.Services.AdminService;
using Hastane.DataAccess.Abstract;
using Hastane.DataAccess.EntityFramework.Concrete;
using Hastane.DataAccess.EntityFramework.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NRM1_HastaneOtomasyon.Models.SeedDataFolder;
using System.Net;
using System.Security.AccessControl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HastaneDbContext>(_ =>
{
    _.UseSqlServer(builder.Configuration.GetConnectionString("HastaneConnectionString"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Login";
    x.AccessDeniedPath = "/Home/Error";
    x.Cookie = new CookieBuilder
    {
        Name = "NrmCookie",
        SecurePolicy = CookieSecurePolicy.Always,  //Accessible by http requests
        HttpOnly = true, //Cookies are accessible by Client - Side
    };
    x.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    x.SlidingExpiration = true;   //If the request is received, the cookie will be extended
    x.Cookie.MaxAge = x.ExpireTimeSpan;
});
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();  //addscope sýralamasýnýn önemi olabilir
builder.Services.AddScoped<IAdminService, AdminService>();  

//builder.Services.AddSession(options => {
//    options.IdleTimeout = TimeSpan.FromMinutes(1);
//    //You can set Time   
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
SeedData.Seed(app);
app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
