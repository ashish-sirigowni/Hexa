using Microsoft.EntityFrameworkCore;

namespace BookMyShowProjectNewAPI.Entity
{
    public class ProjectDbContext : DbContext   
        {
            public DbSet<City> Cities { get; set; }
            public DbSet<MultiplexInfo> MultiplexInfos { get; set; }
            public DbSet<Movie> Movies { get; set; }    
            IConfiguration config = null;
            public ProjectDbContext(IConfiguration cfg)
            {
                config = cfg;
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(config["ConnString"]);
                base.OnConfiguring(optionsBuilder);
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<City>().HasIndex(p => p.CityName).IsUnique(true);
                base.OnModelCreating(modelBuilder);
            }
        }
    }


