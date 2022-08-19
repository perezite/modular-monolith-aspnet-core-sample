using Module.Catalog.Api.Interfaces;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
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

        public async Task<int> Add(Brand brand)
        {
            await _dbContext.Brands.AddAsync(brand);
            await _dbContext.SaveChangesAsync();
            return brand.Id;
        }
    }
}
