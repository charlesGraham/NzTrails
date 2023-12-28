using Microsoft.EntityFrameworkCore;
using NzTrails.Api.Models.Domain;

namespace NzTrails.Api.Data
{
    public class NzWalksDbContext : DbContext
    {
        public NzWalksDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
