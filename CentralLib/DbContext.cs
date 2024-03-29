using Microsoft.EntityFrameworkCore;
using CentralLib.Model;

namespace CentralLib;

public class CentralDbContext : DbContext {


    public CentralDbContext(DbContextOptions<CentralDbContext> options) : base(options) {
    } 


     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "Petar", LastName = "Petrovic", Jmbg = "111111",  Address = "Serifa Konjevica 12, Novi Sad", Loans = 0 },
            new User { Id = 2, FirstName = "Marko", LastName = "Markovic", Jmbg = "222222",  Address = "Nina Resica 12, Novi Sad", Loans = 0 }
        );
    }

    public DbSet<User> Users { get; set; }
}
