using IGEG.ToolShop.Domain.Models;
using IGEG.ToolShop.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IGEG.ToolShop.Persistance.DataContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }       
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Solvent> Solvents { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<News> NewsMenu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
            modelBuilder.ApplyConfiguration(new ProductModelConfiguration());
            modelBuilder.ApplyConfiguration(new SolventConfiguration());
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductOptionConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<Product>().
                Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                entry.Entity.DateOfUpdate = DateTime.Now;

                if (entry.State == EntityState.Added)
                    entry.Entity.DateOfSaller = DateTime.Now;
            } 

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
