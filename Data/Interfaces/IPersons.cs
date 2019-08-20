using Notebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Data.Interfaces
{
    public interface IPersons
    {
        IEnumerable<Person> AllPersons { get; set; }
        void AddPerson(Person person);
        void DeletePerson(int Id);
    }
}
