using Notebook.Data.Interfaces;
using Notebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Data.Repositiry
{
    public class PersonRepository : IPersons
    {
        private readonly AppDbContext appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Person> AllPersons => appDbContext.Person;

        public void AddPerson(Person person)
        {
            appDbContext.Person.Add(person);
            appDbContext.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var person = appDbContext.Person.FirstOrDefault(pers => pers.Id ==id );
            if (person != null)
            {
                appDbContext.Person.Remove(person);
                appDbContext.SaveChanges();
            }
        }

        public IEnumerable<Person> Search(string name, string surname, string phoneNumber)
        {
            IEnumerable<Person> FoundPerson = appDbContext.Person;
            if (name == null && surname == null && phoneNumber == null)
            {
                return FoundPerson;
            }
            if (name != null)
            {
                FoundPerson = appDbContext.Person.Where(x => x.Name != null && x.Name.Contains(name));
            }
            if (surname != null)
            {
                    FoundPerson = FoundPerson.Where(x => x.Surname != null && x.Surname.Contains(surname));
            }
            if (phoneNumber != null)
            {
                    FoundPerson = FoundPerson.Where(x => x.PhoneNumber != null && x.PhoneNumber.Contains(phoneNumber));
            }
            return FoundPerson;
        }

        public IEnumerable<Person> SortPerson(string sortValue)
        {
            IEnumerable<Person> SortedPerson;
            switch (sortValue)
            {
                case "Surname":
                   return SortedPerson = AllPersons.OrderBy(x => x.Surname);
                case "Year":
                    return SortedPerson = AllPersons.OrderBy(x => x.YearOfBirth);
                default:
                    return AllPersons;
            }
        }
    }
}
