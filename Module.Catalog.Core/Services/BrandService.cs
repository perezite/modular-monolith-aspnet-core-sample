using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Module.Catalog.Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly ICatalogDbContext _dbContext;

        public BrandService(ICatalogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> AddAsync(Brand brand)
        {
            await _dbContext.Brands.AddAsync(brand);
            await _dbContext.SaveChangesAsync();
            return brand.Id;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _dbContext.Brands.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
