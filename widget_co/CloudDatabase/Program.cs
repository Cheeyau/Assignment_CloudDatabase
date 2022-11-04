using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Interface;
using Service;
using Repository.Interface;
using Repository;
using DAL;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main() {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(Configure)
            .Build();
        
        host.Run();
    }

    static void Configure(HostBuilderContext builder, IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(ContextString.getString()));
        
        services.AddTransient(typeof(IOrderRepository), typeof(OrderRepository));
        services.AddTransient(typeof(IReviewRepository), typeof(ReviewRepository));
        services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));

        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IUserService, UserService>();
    }
}