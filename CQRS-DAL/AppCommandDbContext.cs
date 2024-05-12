using CQRS_DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS_DAL
{
    public class AppCommandDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=postgresdb;Port=5432;Database=TestDB;User Id=admin;Password=enes123;");

        public DbSet<Product> Products { get; set; }
    }
}
