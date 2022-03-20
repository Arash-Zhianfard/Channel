using ChannelEngine.Merchant.ApiClient.Api;
using Service.Implementation;
using Service.Interfaces;
using Service.Model;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables()
    .Build();
builder.Services.Configure<ChannelApiSetting>(configuration.GetSection("ChannelApiSetting"));
builder.Services
    .AddTransient<IApiCaller, ApiCaller>()
    .AddTransient<IOrderApiAsync, OrderApiAsync>()
    .AddTransient<IOfferApiSync, OfferApiSync>()
    .AddTransient<IStockCharger, StockCharger>()
    .AddTransient<IProductApiAsync, ProductApiAsync>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
