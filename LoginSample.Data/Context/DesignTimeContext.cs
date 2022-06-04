using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LoginSample.Data.Context;

public class DesignTimeContext : IDesignTimeDbContextFactory<LoginSampleDbContext>
{
    public LoginSampleDbContext CreateDbContext(string[] args)
    {
        var connectionString = new ConfigurationBuilder()
                        .SetBasePath(System.IO.Path.Combine(Directory.GetCurrentDirectory()))
                        .AddJsonFile("appsettings.json", false, true).Build().GetSection("MigrationConnectionString").Value;


        var optionsBuilder = new DbContextOptionsBuilder<LoginSampleDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new LoginSampleDbContext(optionsBuilder.Options);
    }
}