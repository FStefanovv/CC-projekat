using Microsoft.EntityFrameworkCore;
using LocalLib.Model;

namespace LocalLib;

public class LocalDbContext : DbContext {

    private readonly IConfiguration _configuration;

    public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) {
    } 


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loan>()
            .Property(l => l.Id)
            .ValueGeneratedOnAdd();
    }

    public DbSet<Loan> Loans { get; set; }
}
