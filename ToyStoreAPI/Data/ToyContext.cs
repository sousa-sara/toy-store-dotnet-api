using Microsoft.EntityFrameworkCore;
using ToyStoreAPI.Models;

namespace ToyStoreAPI.Data
{
    public class ToyContext : DbContext
    {
        public ToyContext(DbContextOptions<ToyContext> options) : base(options) { }

        public DbSet<Toy> Toys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toy>().ToTable("TS_TOYS");
            modelBuilder.Entity<Toy>().HasKey(t => t.IdToy);
            modelBuilder.Entity<Toy>().Property(t => t.IdToy).HasColumnName("ID_TOY");
            modelBuilder.Entity<Toy>().Property(t => t.NameToy).HasColumnName("NAME_TOY");
            modelBuilder.Entity<Toy>().Property(t => t.TypeToy).HasColumnName("TYPE_TOY");
            modelBuilder.Entity<Toy>().Property(t => t.Rating).HasColumnName("RATING");
            modelBuilder.Entity<Toy>().Property(t => t.ToySize).HasColumnName("TOY_SIZE");
            modelBuilder.Entity<Toy>().Property(t => t.Price).HasColumnName("PRICE");
        }
    }
}
