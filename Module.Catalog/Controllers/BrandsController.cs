using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Api.Dtos;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Interfaces;
using System.Linq;
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
            _brandService = brandService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandService.GetAllAsync();
            var brandDtos = brands.Select(x => new BrandDto
            {
                Name = x.Name,
                Detail = x.Detail
            });

            return Ok(brandDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BrandDto brandDto)
        {
            var brand = new Brand
            {
                Name = brandDto.Name,
                Detail = brandDto.Detail
            };

            await _brandService.AddAsync(brand);

            return Ok();
        }
    }
}