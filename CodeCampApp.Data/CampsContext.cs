using CodeCampApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CodeCampApp.Data
{
    public class CampsContext : DbContext
    {
        private readonly IConfiguration config;

        public CampsContext(DbContextOptions<CampsContext> options, IConfiguration config) : base(options)
        {
            this.config = config;
        }

        public DbSet<Camp> Camps { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(this.config.GetConnectionString("CodeCamp"))
                .EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(new Location
            {
                VenueName = "BOgi oiid",
                LocationId = 1
            });

            modelBuilder.Entity<Camp>()
                .HasData(new
                {
                    CampId = 1,
                    EventDate = DateTime.Now,
                    Name = "Atlanta 2021",
                    Length = 15,
                    Moniker = "ATL2021",
                    LocationId = 1
                });
        }
    }
}
