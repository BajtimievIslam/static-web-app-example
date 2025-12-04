using Microsoft.EntityFrameworkCore;

namespace MyWebApplication.Db;

public class WeatherDatabaseContext : DbContext
{
    public WeatherDatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected WeatherDatabaseContext()
    {
    }

    public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer("Server=tcp:serverbaitimiev.database.windows.net,1433;Initial Catalog=dbbaitimiev;Persist Security Info=False;User ID=isai;Password=Bajtimiev_95;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}
