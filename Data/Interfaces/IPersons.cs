using Notebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Data.Interfaces
{
    public interface IPersons
    {
        // When initializing, the list saves all persons from AllPerson.json document.
        IEnumerable<Person> AllPersons { get; }

        // Add the created person to AllPerson.json document.
        void AddPerson(Person person);

        // Remove the selected person from AllPerson.json document. Accepts a person's id as a parameter.
        void DeletePerson(int Id);

        // Search for persons by name, surname and phone number and save it in FoundPerson list. Accepts a person's name, surname and phone number as a parameter.
        IEnumerable<Person> Search(string name, string surname, string phoneNumber);

        // Sorting the list of persons by name or year of birth. Save it in SortedPerson list. Takes the sort selection as a parameter.
        IEnumerable<Person> SortPerson(string sortValue);
    }
}

