using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DWHouse_Dashboard.Models;
using Dashboard_DW_V2.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddDbContext<AuthDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<AuthDBContext>();



// Add services to the container.
builder.Services.AddControllersWithViews();

#region Authorization

AddAuthorizationPolicies(builder.Services);


#endregion

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

//app.MapRazorPages();

app.Run();

void AddAuthorizationPolicies(IServiceCollection services)
{

    services.AddAuthorization(option =>
    option.AddPolicy("AdminOnly", policy =>
       policy.RequireRole("Admin"))


    );
}