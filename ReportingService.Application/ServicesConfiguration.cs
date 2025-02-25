using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ReportingService.Application.Consumers;
using ReportingService.Application.Integration;
using ReportingService.Application.Mappings;
using ReportingService.Application.Services;
using ReportingService.Application.Services.Interfaces;

namespace ReportingService.Application;

public static class ServicesConfiguration
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddAutoMapper(typeof(CustomerMapperProfile).Assembly);
        services.AddTransient<ITransactionService, TransactionService>();
        services.AddTransient<IAccountService, AccountService>();

        //services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));

        //services.AddMassTransit(x =>
        //{
        //    x.AddConsumer<CustomerConsumer>();

        //    x.UsingRabbitMq((context, cfg) =>
        //    {
        //        var settings = context.GetRequiredService<IOptions<RabbitMQSettings>>().Value;

        //        cfg.Host(settings.Host, settings.VirtualHost, h =>
        //        {
        //            h.Username(settings.Username);
        //            h.Password(settings.Password);
        //        });

        //        cfg.ReceiveEndpoint(settings.QueueName, e =>
        //        {
        //            e.ConfigureConsumer<CustomerConsumer>(context);
        //        });
        //    });
        //});
    }
}
