using Notebook.Data.Interfaces;
using Notebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Notebook.Data.Mocks
{
    public class MockPersons : IPersons
    {
        private string _serialised;
        private static List<Person> _personlist = new List<Person>(); 
        
    public IEnumerable<Person> AllPersons
        {
            get
            {
                if (!File.Exists("AllPerson.json"))
                {
                    _serialised = JsonConvert.SerializeObject(_personlist);
                    File.WriteAllText("AllPerson.json", _serialised);
                }

                else if (File.Exists("AllPerson.json"))
                {
                    _serialised = File.ReadAllText("AllPerson.json");
                    var pers = JsonConvert.DeserializeObject<List<Person>>(_serialised);
                    return pers;
                }
                return _personlist;
            }

            set { }
        }

        public IEnumerable<Person> SortedPerson { get ; set; }

        public void AddPerson(Person person)
        {
            LoadList();
            person.Id = _personlist.Max(x => x.Id)+1;
            _personlist.Add(person);
            SaveList();
        }

        public void DeletePerson(int Id)
        {
            LoadList();
            _personlist.Remove(_personlist.Where(x => x.Id == Id).FirstOrDefault());
            SaveList();
        }

        public void Search(string name, string surname, string phoneNumber)
        {

            LoadList();
            if (name == null && surname == null && phoneNumber == null)
            {
                SortedPerson = _personlist;
                return;
            }
            if(name !=null)
            SortedPerson = _personlist.Where(x => x.Name != null && x.Name.Contains(name));
            if (surname != null)
            {
                if(SortedPerson != null)
                    SortedPerson = SortedPerson.Where(x => x.Surname != null && x.Surname.Contains(surname));
                else
                    SortedPerson = _personlist.Where(x => x.Surname != null && x.Surname.Contains(surname));
            }
            if (phoneNumber != null)
            {
                if (SortedPerson != null)
                    SortedPerson = SortedPerson.Where(x => x.PhoneNumber != null && x.PhoneNumber.Contains(phoneNumber));
                else
                    SortedPerson = _personlist.Where(x => x.PhoneNumber != null && x.PhoneNumber.Contains(phoneNumber));
            }
        }

        public void LoadList()
        {
            _serialised = File.ReadAllText("AllPerson.json");
            _personlist = JsonConvert.DeserializeObject<List<Person>>(_serialised);
        }

        public void SaveList()
        {
            _serialised = JsonConvert.SerializeObject(_personlist);
            File.WriteAllText("AllPerson.json", _serialised);
        }
    }
}
