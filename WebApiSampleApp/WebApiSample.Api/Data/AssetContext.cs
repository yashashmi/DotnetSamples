using Microsoft.EntityFrameworkCore;
using WebApiSample.Api.Models;
namespace WebApiSample.Api.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext(DbContextOptions<AssetContext> options) : base(options)
        { }
        public DbSet<Asset> Asset { get; set; }
    }
}