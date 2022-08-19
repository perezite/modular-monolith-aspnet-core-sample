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

        //public async Task<int> Handle(RegisterBrandCommand command, CancellationToken cancellationToken)
        //{
        //    if (await _context.Brands.AnyAsync(c => c.Name == command.Name, cancellationToken))
        //    {
        //        throw new Exception("Brand with the same name already exists.");
        //    }
        //    var brand = new Brand { Detail = command.Detail, Name = command.Name };
        //    await _context.Brands.AddAsync(brand, cancellationToken);
        //    await _context.SaveChangesAsync(cancellationToken);
        //    return brand.Id;

        //pubic async Task<int> Add()
        public async Task<int> Add(Brand brand)
        {
            await _dbContext.Brands.AddAsync(brand);
            await _dbContext.SaveChangesAsync();
            return brand.Id;
        }
    }
}
