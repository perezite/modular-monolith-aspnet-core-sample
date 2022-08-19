using Microsoft.EntityFrameworkCore;
using Module.People.Core.Entities;
using Module.People.Core.Interfaces;
using Shared.Infrastructure.Persistence;

namespace Module.People.Infrastructure.Persistence
{
    public class PersonDbContext : ModuleDbContext, IPersonDbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        protected override string Schema => "People";

        public DbSet<Person> People { get; set; }
    }
}