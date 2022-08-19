using Module.People.Core.Entities;
using Module.People.Core.Interfaces;
using System.Threading.Tasks;

namespace Module.People.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonDbContext _dbContext;

        public PersonService(IPersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Person person)
        {
            await _dbContext.People.AddAsync(person); ;
            await _dbContext.SaveChangesAsync();
            return person.Id;
        }
    }
}
