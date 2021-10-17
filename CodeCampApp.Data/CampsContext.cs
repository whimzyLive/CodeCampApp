using CodeCampApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


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
            builder.UseSqlServer(this.config.GetConnectionString("CodeCamp"));
        }
    }
}
