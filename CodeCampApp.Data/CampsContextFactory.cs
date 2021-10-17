using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CodeCampApp.Data
{
    public class CampsContextFactory : IDesignTimeDbContextFactory<CampsContext>
    {

        public CampsContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath($"{Directory.GetParent(Directory.GetCurrentDirectory())}/CodeCampApp.API")
            .AddJsonFile("appsettings.json")
            .Build();
            return new CampsContext(new DbContextOptionsBuilder<CampsContext>().Options, configuration);
        }
    }
}
