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
        // Creating a field IPersons.
        private readonly IPersons _persons;

        // Initializing a field in the constructor.
        public PersonController(IPersons persons)
        {
            _persons = persons;
        }

        // The start-up of the default view.
        public ViewResult Index()
        {
            Validate val = new Validate();
            ViewBag.NotValid = val;
            return View(_persons.AllPersons);
        }

        // The method runs when you call the create method of. Name, surname, phone number and year of birth are accepted as a parameter.
        [HttpPost]
        [Route("Person/Create")]
        public ViewResult Index(string surname, string name, string phoneNamber, int yearOfBirth)
        {
            Validate val = new Validate();
            val.ValidatePerson(surname, name, phoneNamber, yearOfBirth);
            if (val.Valid)
            {
                _persons.AddPerson(new Person(surname, name, phoneNamber, yearOfBirth));
            }
                ViewBag.NotValid = val;
            return View(_persons.AllPersons);
        }

        // Starts the view method when the delete method is called.ID is accepted as a parameter.
        [Route("Person/Delete/{Id}")]
        public ViewResult Index(int Id)
        {
            Validate val = new Validate();
            ViewBag.NotValid = val;
            _persons.DeletePerson(Id);
            return View(_persons.AllPersons);
        }
        
        //Starts the view method when the search method is called.The parameter is the first name, last name, and phone number.
        [Route("Person/Search")]
        public ViewResult Index(string name, string surname, string phoneNamber)
        {
            Validate val = new Validate();
            ViewBag.NotValid = val;
            _persons.Search(name, surname, phoneNamber);
            return View(_persons.FoundPerson);
        }

        // Starts the view method when the sort method is called.The parameter is set to sort selection.
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
