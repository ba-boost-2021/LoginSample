using LoginSample.Entites.Main;
using LoginSample.Entites.Users;
using Microsoft.EntityFrameworkCore;

namespace LoginSample.Data.Context;

public class LoginSampleDbContext : DbContext
{
    public LoginSampleDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<LookUp> LookUps { get; set; }
    public DbSet<LookUpType> LookUpTypes { get; set; }
    public DbSet<SystemParameter> SystemParameters { get; set; }

}