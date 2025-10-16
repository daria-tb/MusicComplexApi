using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MusicComplexRepositories
{
    public class MusicDbContextFactory : IDesignTimeDbContextFactory<MusicDbContext>
    {
        public MusicDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5436;Database=postgres;Username=user;Password=1111");

            return new MusicDbContext(optionsBuilder.Options);
        }
    }
}