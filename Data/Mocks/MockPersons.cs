using Notebook.Data.Interfaces;
using Notebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Data.Mocks
{
    public class MockPersons : IPersons
    {
        public IEnumerable<Person> AllPersons
        {
            get
            {
                return new List<Person>
                {
                    new Person(1,"Сперенков","Максим","89518842311", 1987),
                    new Person(2,"Сперенкова","Елизавета","89618961245",1993)
                };
            }

            set
            {

            }
        }
    }
}
