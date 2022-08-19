using Module.Catalog.Core.Entities;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Interfaces
{
    public interface IBrandService
    {
        Task<int> AddAsync(Brand brand);
    }
}
