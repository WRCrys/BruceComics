using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevCA.Business.Model;
using Microsoft.EntityFrameworkCore;

namespace DevCa.Data.Context
{
    public class BruceComicsContext : DbContext
    {
        public BruceComicsContext(DbContextOptions<BruceComicsContext> options) : base(options) { }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGender> BookGenders { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BruceComicsContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DateRegistration") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateRegistration").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateRegistration").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}