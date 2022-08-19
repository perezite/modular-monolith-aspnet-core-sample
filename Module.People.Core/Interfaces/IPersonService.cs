using Module.People.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.People.Core.Interfaces
{
    public interface IPersonService
    {
        Task<int> AddAsync(Person person);
    }
}
