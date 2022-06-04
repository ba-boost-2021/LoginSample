using Microsoft.Extensions.Configuration;
using LoginSample.Common;
using Microsoft.Extensions.DependencyInjection;
using LoginSample.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoginSample.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection($"{nameof(Settings)}");
        var settings = section.Get<Settings>();
        services.AddDbContext<LoginSampleDbContext>(builder =>
        {
            builder.UseSqlServer(settings.Database.ConnectionString);
        });
        return services;
    }
}

/*
 
 "Settings": {
    "Database": {
      "ConnectionString": "Server=localhost,20000;Database=LoginSampleDb;User Id=sa;Password=Bilgeadam123!"
    }
  }
 */