using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace RandomUserApp.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebAppDatabase"));
        }

        public DbSet<Produto> Produto { get; set; }
    }
}
