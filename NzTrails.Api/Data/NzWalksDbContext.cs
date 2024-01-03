using Microsoft.EntityFrameworkCore;
using NzTrails.Api.Models.Domain;

namespace NzTrails.Api.Data
{
    public class NzWalksDbContext : DbContext
    {
        public NzWalksDbContext(DbContextOptions<NzWalksDbContext> options)
            : base(options) { }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data for Difficulties
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("2616c7a2-361e-4bfe-8fb1-7e6b78613110"),
                    Name = "Easy",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("a67fd31c-48b4-4512-af85-a5026b9dc8ac"),
                    Name = "Medium",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("b909e102-859a-403f-ba9e-94630407ca1e"),
                    Name = "Hard",
                }
            };

            // pass to db
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // seed region data
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("f78584b4-ba8e-40e8-82a7-6e4aa86db26d"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "auckland-region-img.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("739d1a2e-d7a3-4c8d-aa7b-b57087ce001f"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "wellington-region-img.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("170c6236-1b93-43ee-a27b-9c698c5214d3"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "nelson-region-img.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("6a12ef70-b748-40a3-8033-307ae17da5fa"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "southland-region-img.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
