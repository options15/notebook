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
        public IEnumerable<Person> FoundPerson { get; set; }
        public IEnumerable<Person> SortedPerson { get; set; }

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

        public void Search(string name, string surname, string phoneNumber)
        {
            if (name == null && surname == null && phoneNumber == null)
            {
                FoundPerson = appDbContext.Person;
                return;
            }
            if (name != null)
                FoundPerson = appDbContext.Person.Where(x => x.Name != null && x.Name.Contains(name));
            if (surname != null)
            {
                if (FoundPerson != null)
                    FoundPerson = FoundPerson.Where(x => x.Surname != null && x.Surname.Contains(surname));
                else
                    FoundPerson = appDbContext.Person.Where(x => x.Surname != null && x.Surname.Contains(surname));
            }
            if (phoneNumber != null)
            {
                if (FoundPerson != null)
                    FoundPerson = FoundPerson.Where(x => x.PhoneNumber != null && x.PhoneNumber.Contains(phoneNumber));
                else
                    FoundPerson = appDbContext.Person.Where(x => x.PhoneNumber != null && x.PhoneNumber.Contains(phoneNumber));
            }
        }

        public void SortPerson(string sortValue)
        {
            switch (sortValue)
            {
                case "Surname":
                    SortedPerson = AllPersons.OrderBy(x => x.Surname);
                    return;
                case "Year":
                    SortedPerson = AllPersons.OrderBy(x => x.YearOfBirth);
                    return;
                default:
                    return;
            }
        }
    }
}
