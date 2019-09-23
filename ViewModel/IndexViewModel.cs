using Notebook.Data.Models;
using Notebook.Data.ValidateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Person> PersonModel;

        public Validate val = new Validate();
    }
}
