using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Api.Dtos;
using Module.Catalog.Core.Commands.Register;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Queries.GetAll;
using System.Threading.Tasks;

namespace Module.Catalog.Api.Controllers
{
    [ApiController]
    [Route("/api/catalog/[controller]")]
    internal class BrandsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBrandDto dto)
        {
            var entity = new Brand
            {
                Name = dto.Name,
                Detail = dto.Detail
            };

            await Task.CompletedTask;



            return Ok();
        }
    }
}