using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Data.Models
{
    public class Person
    {
        // List of person model fields. Contains Id, Surname, Name, Phone number and Year Of Birth.
        public int Id { get; set; }
        public string Surname {get; set;}
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int YearOfBirth { get; set; }
        // The constructor is populated when the object is initialized.
        public Person(string Surname, string Name, string PhoneNumber, int YearOfBirth)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.YearOfBirth = YearOfBirth;
        }
    }
}
