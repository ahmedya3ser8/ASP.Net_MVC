var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(config =>
{
    config.IdleTimeout = TimeSpan.FromMinutes(30);
});

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

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
