using Microsoft.AspNetCore.Mvc;
using Notebook.Data.Interfaces;
using Notebook.Data.Models;
using Notebook.Data.ValidateModel;
using Notebook.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Controllers
{
    public class PersonController : Controller
    {
        // Creating a field IPersons.
        private readonly IPersons persons;
        IndexViewModel indexViewModel = new IndexViewModel();

        // Initializing a field in the constructor.
        public PersonController(IPersons persons)
        {
            this.persons = persons;
        }

        // The start-up of the default view.
        public ViewResult Index()
        {
            indexViewModel.PersonModel = persons.AllPersons;
            return View(indexViewModel);
        }

        // The method runs when you call the create method of. Name, surname, phone number and year of birth are accepted as a parameter.
        [HttpPost]
        [Route("Person/Create")]
        public ViewResult Index(string surname, string name, string phoneNumber, int yearOfBirth)
        {
            indexViewModel.PersonModel = persons.AllPersons;
            indexViewModel.val.ValidatePerson(surname, name, phoneNumber, yearOfBirth);
            if (indexViewModel.val.Valid)
            {
                persons.AddPerson(new Person(surname, name, phoneNumber, yearOfBirth));
            }
            return View(indexViewModel);
        }

        // Starts the view method when the delete method is called.ID is accepted as a parameter.
        [Route("Person/Delete/{Id}")]
        public ViewResult Index(int Id)
        {
            persons.DeletePerson(Id);
            indexViewModel.PersonModel = persons.AllPersons;
            return View(indexViewModel);
        }
        
        //Starts the view method when the search method is called.The parameter is the first name, last name, and phone number.
        [Route("Person/Search")]
        public ViewResult Index(string name, string surname, string phoneNumber)
        {
            indexViewModel.PersonModel = persons.Search(name, surname, phoneNumber);
            return View(indexViewModel);
        }

        // Starts the view method when the sort method is called.The parameter is set to sort selection.
        [Route("Person/Sort")]
        public ViewResult Index(string sortValue)
        {
            indexViewModel.PersonModel = persons.SortPerson(sortValue);
            return View(indexViewModel);
        }
    }
}
