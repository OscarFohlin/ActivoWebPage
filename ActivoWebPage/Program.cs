using Hv.Sos100.SingleSignOn;
using ActivoWebPage.Controllers;
using static ActivoWebPage.Controllers.HomeController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//SSO
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddSession();
builder.Services.AddTransient<HomeController.EventApiService>();

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
