using Microsoft.EntityFrameworkCore;
using Module.People.Core.Entities;
using System.Threading.Tasks;

namespace Module.People.Core.Interfaces
{
    public interface IPersonDbContext
    {
        public DbSet<Person> People { get; set; }

        Task<int> SaveChangesAsync();
    }
}
