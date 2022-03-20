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
            .AddSingleton<IProductApiAsync, ProductApiAsync>()
            .AddSingleton<IStockCharger, StockCharger>();        
    }
}

public class Executor
{
    private readonly IOrderApiAsync _orderApiAsync;
    private readonly IStockCharger _stockCharger;
    private readonly IProductApiAsync _productAsync;

    public Executor(IOrderApiAsync orderApiAsync, IStockCharger stockCharger, IProductApiAsync productAsync, IOptions<ChannelApiSetting> setupOptions)
    {
        _orderApiAsync = orderApiAsync;
        _stockCharger = stockCharger;
        _productAsync = productAsync;
    }

    public void Execute()
    {
        
        Console.WriteLine("getting data...");
        //Task.Run used to not block the main thread
        var orderTask = Task.Run(() => _orderApiAsync.GetByFilterAsync(new OrderFilterOption()
        {
            Statuses = new List<ChannelEngine.Merchant.ApiClient.Model.OrderStatusView>()
            {
                ChannelEngine.Merchant.ApiClient.Model.OrderStatusView.IN_PROGRESS
            }
        }));
        var top5ProductTask = Task.Run(() => _productAsync.GetTopSoldProduct(5));
        var updateStockTask= Task.Run(() => _stockCharger.UpdateStockCountAsync());

        Task.WaitAll(orderTask, top5ProductTask, updateStockTask);

        Console.WriteLine("product with filters,press any key...");
        Console.ReadKey();
        foreach (var item in orderTask.Result.Content)
        {
            Console.WriteLine(item.ToJson());
        }
        Console.WriteLine("get top 5 sold product,press any key...");
        Console.ReadKey();
        foreach (var product in top5ProductTask.Result)
        {
            Console.WriteLine(product.ToJson());
        }
        Console.WriteLine("update stock result,press any key...");
        Console.ReadKey();
        Console.WriteLine(updateStockTask.Result.ToJson());



        Console.ReadKey();
    }
}