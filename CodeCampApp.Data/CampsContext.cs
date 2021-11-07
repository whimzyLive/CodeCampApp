using CodeCampApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CodeCampApp.Data
{
    public class CampsContext : DbContext
    {
        private readonly IConfiguration _config;

        public CampsContext(DbContextOptions<CampsContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Camp> Camps { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_config.GetConnectionString("CodeCamp"))
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

            modelBuilder.Entity<Talk>()
            .HasData(new
            {
                TalkId = 1,
                CampId = 1,
                SpeakerId = 1,
                Title = "Entity Framework From Scratch",
                Abstract = "Entity Framework from scratch in an hour. Probably cover it all",
                Level = 100
            },
            new
            {
                TalkId = 2,
                CampId = 1,
                SpeakerId = 2,
                Title = "Writing Sample Data Made Easy",
                Abstract = "Thinking of good sample data examples is tiring.",
                Level = 200
            });

            modelBuilder.Entity<Speaker>()
            .HasData(new
            {
                SpeakerId = 1,
                FirstName = "Shawn",
                LastName = "Wildermuth",
                BlogUrl = "http://wildermuth.com",
                Company = "Wilder Minds LLC",
                CompanyUrl = "http://wilderminds.com",
                GitHub = "shawnwildermuth",
                Twitter = "shawnwildermuth"
            }, new
            {
                SpeakerId = 2,
                FirstName = "Resa",
                LastName = "Wildermuth",
                BlogUrl = "http://shawnandresa.com",
                Company = "Wilder Minds LLC",
                CompanyUrl = "http://wilderminds.com",
                GitHub = "resawildermuth",
                Twitter = "resawildermuth"
            });
        }
    }
}
