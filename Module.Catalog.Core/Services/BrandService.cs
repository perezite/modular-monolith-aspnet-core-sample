using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Interfaces;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly ICatalogDbContext _dbContext;

        public BrandService(ICatalogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        async Task<int> IBrandService.AddAsync(Brand brand)
        {
            await _dbContext.Brands.AddAsync(brand);
            await _dbContext.SaveChangesAsync();
            return brand.Id;
        }
    }
}
