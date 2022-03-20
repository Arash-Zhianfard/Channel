using ChannelEngine.Merchant.ApiClient.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Service.Implementation;
using Service.Interfaces;
using Service.Model;
class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        services
            .AddSingleton<Executor, Executor>()
            .BuildServiceProvider()
            .GetService<Executor>()
            .Execute();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .AddEnvironmentVariables()
        .Build();
        services.Configure<ChannelApiSetting>(configuration.GetSection("ChannelApiSetting"));
        services
            .AddSingleton<IApiCaller, ApiCaller>()
            .AddSingleton<IOrderApiAsync, OrderApiAsync>()
        .AddSingleton<IOfferApiSync, OfferApiSync>()
        .AddSingleton<IProductApiAsync, ProductApiAsync>();
    }
}

public class Executor
{
    private readonly IOrderApiAsync _orderApiAsync;
    private readonly IOfferApiSync _offerApiSync;
    private readonly IProductApiAsync _productAsync;

    public Executor(IOrderApiAsync orderApiAsync, IOfferApiSync offerApiSync, IProductApiAsync productAsync, IOptions<ChannelApiSetting> setupOptions)
    {
        _orderApiAsync = orderApiAsync;
        _offerApiSync = offerApiSync;
        _productAsync = productAsync;
    }

    public void Execute()
    {
        Console.WriteLine("get product orders by filter,press any key");
        Console.ReadKey();
        var filteredOrder = _orderApiAsync.GetByFilterAsync(new OrderFilterOption()
        {
            Statuses = new List<ChannelEngine.Merchant.ApiClient.Model.OrderStatusView>()
            {
                ChannelEngine.Merchant.ApiClient.Model.OrderStatusView.IN_PROGRESS
            }
        }).Result;
        foreach (var item in filteredOrder.Content)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("get top 5 sold product,press any key");
        Console.ReadKey();
        var top5SoldProduct = _productAsync.GetTopSoldProduct(5).Result;
        foreach (var product in top5SoldProduct)
        {
            Console.WriteLine(product.ToString());
        }
        Console.WriteLine("Update stock,press any key");
        Console.ReadKey();
        var stockOrder = _offerApiSync.UpdateStockCountAsync().Result;
        Console.WriteLine(stockOrder.ToString());
        Console.ReadKey();
    }
}