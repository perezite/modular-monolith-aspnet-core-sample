namespace Module.Catalog.Api.Interfaces
{
    public interface IBrandService
    {
        Task<int> Add(Brand brand);
    }
}
