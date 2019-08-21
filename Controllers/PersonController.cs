using Microsoft.AspNetCore.Mvc;
using Notebook.Data.Interfaces;
using Notebook.Data.Models;
using Notebook.Data.ValidateModel;
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
            Validate val = new Validate();
            ViewBag.NotValid = val;
            return View(_persons.AllPersons);
        }
        [HttpPost]
        [Route("Person/Create")]
        public ViewResult Index(string surname, string name, string phoneNamber, int yearOfBirth)
        {
            Validate val = new Validate();
            val.ValidatePerson(surname, name, phoneNamber, yearOfBirth);
            if (val.valid)
            {
                _persons.AddPerson(new Person(surname, name, phoneNamber, yearOfBirth));
            }
                ViewBag.NotValid = val;
            return View(_persons.AllPersons);
        }
        [Route("Person/Delete/{Id}")]
        public ViewResult Index(int Id)
        {
            Validate val = new Validate();
            ViewBag.NotValid = val;
            _persons.DeletePerson(Id);
            return View(_persons.AllPersons);
        }
        [Route("Person/Search")]
        public ViewResult Index(string name, string surname, string phoneNamber)
        {
            Validate val = new Validate();
            ViewBag.NotValid = val;
            _persons.Search(name, surname, phoneNamber);
            return View(_persons.FoundPerson);
        }
        [Route("Person/Sort")]
        public ViewResult Index(string sortValue)
        {
            Validate val = new Validate();
            ViewBag.NotValid = val;
            _persons.SortPerson(sortValue);
            return View(_persons.SortedPerson);
        }
    }
}
