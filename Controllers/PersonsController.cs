using Microsoft.AspNetCore.Mvc;
using Notebook.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersons _persons;

        public PersonsController(IPersons persons)
        {
            _persons = persons;
        }
        public ViewResult List()
        {
            var persons = _persons.AllPersons;
            return View(persons);
        }
    }
}
