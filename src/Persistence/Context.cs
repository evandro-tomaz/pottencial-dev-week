using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(table =>
        {
            table.HasKey(e => e.Id);
            table.HasMany(e => e.Contracts).WithOne().HasForeignKey(c => c.PersonId);
        });

        modelBuilder.Entity<Contract>(table =>
        {
            table.HasKey(e => e.Id);
        });
    }
}