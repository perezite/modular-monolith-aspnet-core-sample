using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Api.Dtos;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Interfaces;
using System.Threading.Tasks;

namespace Module.Catalog.Api.Controllers
{
    [ApiController]
    [Route("/api/catalog/[controller]")]
    internal class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            this._brandService = brandService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBrandDto dto)
        {
            var brand = new Brand
            {
                Name = dto.Name,
                Detail = dto.Detail
            };

            await _brandService.AddAsync(brand);

            return Ok();
        }
    }
}