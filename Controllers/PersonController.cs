using Microsoft.AspNetCore.Mvc;
using Notebook.Data.Interfaces;
using Notebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersons _persons;
        public PersonController(IPersons persons)
        {
            _persons = persons;
        }

        public ViewResult Index()
        {
            return View(_persons.AllPersons);
        }
        [HttpPost]
        [Route("Person/Create")]
        public ViewResult Index(string surname, string name, string phoneNamber, int yearOfBirth)
        {
                    _persons.AddPerson(new Person(surname, name, phoneNamber, yearOfBirth));
                    return View(_persons.AllPersons);
        }
        [Route("Person/Delete/{Id}")]
        public ViewResult Index(int Id)
        {
            _persons.DeletePerson(Id);
            return View(_persons.AllPersons);
        }
        [Route("Person/Search")]
        public ViewResult Index(string name, string surname, string phoneNamber)
        {
            _persons.Search(name, surname, phoneNamber);
            return View(_persons.FoundPerson);
        }
        [Route("Person/Sort")]
        public ViewResult Index(string sortValue)
        {
            _persons.SortPerson(sortValue);
            return View(_persons.SortedPerson);
        }
    }
}
