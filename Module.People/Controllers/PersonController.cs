using Microsoft.AspNetCore.Mvc;
using Module.People.Api.Dtos;
using Module.People.Core.Entities;
using Module.People.Core.Interfaces;
using System.Threading.Tasks;

namespace Module.People.Api.Controllers
{
    [ApiController]
    [Route("/api/people/[controller]")]
    internal class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonDto personDto)
        {
            var person = new Person
            {
                Name = personDto.Name,
                Age = personDto.Age
            };

            var id = await _personService.AddAsync(person);

            return Ok(id);
        }
    }
}