using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Interface;
using Service;
using Repository.Interface;
using Repository;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;

public class Program
{
    public static void Main() {
        IHost host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureOpenApi()
            .ConfigureServices((HostBuilderContext context, IServiceCollection services) =>
            {
                services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(ContextString.getString()));

                services.AddTransient(typeof(IOrderRepository), typeof(OrderRepository));
                services.AddTransient(typeof(IReviewRepository), typeof(ReviewRepository));
                services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
                services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));

                services.AddScoped<IOrderService, OrderService>();
                services.AddScoped<IProductService, ProductService>();
                services.AddScoped<IReviewService, ReviewService>();
                services.AddScoped<IUserService, UserService>();
            })
            .Build();
        host.Run();
    }
}