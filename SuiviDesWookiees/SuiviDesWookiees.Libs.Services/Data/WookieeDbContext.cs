using Microsoft.EntityFrameworkCore;

namespace SuiviDesWookiees.Libs.Services.Data
{
    public class WookieeDbContext : DbContext
    {
        protected WookieeDbContext()
        {
        }

        public WookieeDbContext(DbContextOptions<WookieeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Wookiee>().HasKey(x => x.Id);
            modelBuilder.Entity<Wookiee>().Property(x => x.Surname).HasMaxLength(64);

            modelBuilder.Entity<Position>().HasKey(x => x.X);
        }

        public DbSet<Wookiee> Wookiees { get; set; } // Table en bdd s'appelle, par défaut Wookiees
    }
}
