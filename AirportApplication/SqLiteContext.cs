namespace AirportApplication;
using Models;
using Microsoft.EntityFrameworkCore;

public class SqLiteContext : DbContext
{
    public DbSet<Country>? Countries { get; set; }
    public DbSet<City>? Cities { get; set; }
    public DbSet<Airport>? Airports { get; set; }
    public DbSet<Flight>? Flights { get; set; }
    public DbSet<Seat>? Seats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=db.sqlite");
}