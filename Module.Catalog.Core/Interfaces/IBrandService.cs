using Module.Catalog.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Interfaces
{
    public interface IBrandService
    {
        Task<int> AddAsync(Brand brand);
        Task<List<Brand>> GetAllAsync();
    }
}
