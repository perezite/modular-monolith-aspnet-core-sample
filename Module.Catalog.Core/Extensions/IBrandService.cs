using Module.Catalog.Core.Entities;
using System.Threading.Tasks;

namespace Module.Catalog.Api.Interfaces
{
    public interface IBrandService
    {
        Task<int> Add(Brand brand);
    }
}
