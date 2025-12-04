using Microsoft.EntityFrameworkCore;

namespace AzureWebApp.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }

    public DbSet<WeatherEntity> Weathers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WeatherEntity>(entity =>
        {
            entity.HasKey(e => e.Date);
            entity.Property(e => e.Summary).HasMaxLength(200);
        });

        // Seed data
        modelBuilder.Entity<WeatherEntity>().HasData(
            new WeatherEntity { Date = new DateOnly(2024, 1, 1), TemperatureC = 15, Summary = "Cool" },
            new WeatherEntity { Date = new DateOnly(2024, 1, 2), TemperatureC = 22, Summary = "Warm" },
            new WeatherEntity { Date = new DateOnly(2024, 1, 3), TemperatureC = -5, Summary = "Freezing" },
            new WeatherEntity { Date = new DateOnly(2024, 1, 4), TemperatureC = 30, Summary = "Hot" },
            new WeatherEntity { Date = new DateOnly(2024, 1, 5), TemperatureC = 18, Summary = "Mild" }
        );
    }
}
