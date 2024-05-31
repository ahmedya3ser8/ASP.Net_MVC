using Demo_MVC.Models;
using Demo_MVC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(config =>
{
    config.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddDbContext<AppDbContext>(cfg => cfg.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
// option => option.Password.RequireUppercase = false; --> ovveride policy

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*
    Pipline:
        * catch Request
        * build Response

    --------------------------
    Types Of Middlewares:
       * Built In Middleware 
       * Custom Middleware 
       * Package Middleware 

    Middlewares:
        1) Execute Request, call next middleware --> Use 
        2) Execute Request, Terminate --> Run 
        3) Map (URL, Execute)

    * RequestDelegate  -----  Invoke
*/

/*
app.Use(async(httpClient, next) =>
{
    // Write Respone
    await httpClient.Response.WriteAsync("Middleware 1");
    // call next
    await next.Invoke();
	await httpClient.Response.WriteAsync("\nMiddleware 1 back");
});

app.Use(async(httpClient, next) =>
{
    // Write Respone
    await httpClient.Response.WriteAsync("\nMiddleware 2");
    // call next
    await next.Invoke();
	await httpClient.Response.WriteAsync("\nMiddleware 2 back");
});

app.Run(async(httpClient) =>
{
    // Write Respone
    await httpClient.Response.WriteAsync("\nTerminate ");
});
*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

/*
 * {controller=Home}/{action=Index}/{id?}
 *      segment     delemeter        placeholder
*/

// URL --> emp/1  == Employee/Details/1
app.MapControllerRoute("Route1",
    "emp/{id:int}",
    new
    {
        controller = "Employee",
        action = "Details"
    }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
