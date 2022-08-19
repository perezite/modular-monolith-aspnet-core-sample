using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Entities;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Interfaces
{
    public interface ICatalogDbContext
    {
        public DbSet<Brand> Brands { get; set; }

        Task<int> SaveChangesAsync();
    }
}