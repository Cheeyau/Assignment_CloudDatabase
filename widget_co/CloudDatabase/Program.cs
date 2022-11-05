using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Interface;
using Service;
using Repository.Interface;
using Repository;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static void Main() {
        IHost host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureOpenApi()
            .ConfigureServices((HostBuilderContext context, IServiceCollection services) =>
            {
                services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(ContextString.getString()));

                services.AddTransient(typeof(ICreateRepository<>), typeof(CreateRepository<>));
                services.AddTransient(typeof(IDeleteRepository<>), typeof(DeleteRepository<>));
                services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
                services.AddTransient(typeof(IUpdateRepository<>), typeof(UpdateRepository<>));

                services.AddScoped<IOrderService, CRUDOrderService>();
                services.AddScoped<ICRUDService, CRUDProductService>();
                services.AddScoped<IReviewService, CRUDReviewService>();
                services.AddScoped<IUserService, CRUDUserService>();
            })
            .Build();
        host.Run();
    }
}