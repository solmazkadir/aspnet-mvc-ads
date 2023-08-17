using App.Data;
using App.Data.Abstract;
using App.Data.Concrete;
using App.Service.Abstract;
using App.Service.Concrete;
using AspNetMvcAds.Service.Abstract;
using AspNetMvcAds.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string? DbStr = builder.Configuration.GetConnectionString("DbStr");
    options.UseSqlServer(DbStr);
});

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));

builder.Services.AddTransient<IAdvertCommentService, AdvertCommentService>();

builder.Services.AddTransient<IAdvertImageService, AdvertImageService>();

//builder.Services.AddTransient<IAdvertService, AdvertService>();

//builder.Services.AddTransient<ICategoryAdvertService, CategoryAdvertService>();
builder.Services.AddTransient<ISettingService, SettingService>();
builder.Services.AddTransient<IUserRoleService, UserRoleService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login";
    x.LogoutPath = "/Admin/Logout";
    x.AccessDeniedPath = "/AccessDenied";
    x.Cookie.Name = "Administrator";
    x.Cookie.MaxAge = TimeSpan.FromDays(1);
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", p => p.RequireClaim("Role", "Admin"));
    x.AddPolicy("UserPolicy", p => p.RequireClaim("Role", "User"));
});


builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

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

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!await dbContext.Database.CanConnectAsync())
    {
        await dbContext.Database.EnsureCreatedAsync();

        await DbSeeder.Seed(dbContext);
    }
}

app.Run();
