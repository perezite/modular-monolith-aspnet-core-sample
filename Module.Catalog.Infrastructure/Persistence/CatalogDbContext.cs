using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Interfaces;
using Shared.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace Module.Catalog.Infrastructure.Persistence
{
    public class CatalogDbContext : ModuleDbContext, ICatalogDbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        protected override string Schema => "Catalog";

        public DbSet<Brand> Brands { get; set; }
    }
}