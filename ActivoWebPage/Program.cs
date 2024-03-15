using ActivoWebPage.Controllers;
using Hv.Sos100.SingleSignOn;
using static ActivoWebPage.Controllers.HomeController;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//SSO
builder.Services.AddHttpClient(); // Lägg till HTTPClientFactory som en tjänst

builder.Services.AddScoped<EventApiService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddSession();
builder.Services.AddTransient<HomeController.EventApiService>();
builder.Services.AddTransient<HomeController.ActivitiesApiService>();
builder.Services.AddTransient<HomeController.PlacesApiService>();


var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
