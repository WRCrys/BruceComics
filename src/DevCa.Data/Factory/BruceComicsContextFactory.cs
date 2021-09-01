using DevCa.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevCa.Data.Factory
{
    public class BruceComicsContextFactory : IDesignTimeDbContextFactory<BruceComicsContext>
    {
        public BruceComicsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BruceComicsContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=BruceComics;User Id=sa;Password=Egypt.Origins;Trusted_Connection=False;MultipleActiveResultSets=true");

            return new BruceComicsContext(optionsBuilder.Options);
        }
    }
}
