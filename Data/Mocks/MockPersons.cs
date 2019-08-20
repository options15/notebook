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

        public void AddPerson(Person person)
        {
            _serialised = File.ReadAllText("AllPerson.json");
            _personlist = JsonConvert.DeserializeObject<List<Person>>(_serialised);
            person.Id = _personlist.Max(x => x.Id)+1;
            _personlist.Add(person);
            _serialised = JsonConvert.SerializeObject(_personlist);
            File.WriteAllText("AllPerson.json", _serialised);
        }

        public void DeletePerson(int Id)
        {
            _serialised = File.ReadAllText("AllPerson.json");
            _personlist = JsonConvert.DeserializeObject<List<Person>>(_serialised);

            _personlist.Remove(_personlist.Where(x => x.Id == Id).FirstOrDefault());

            _serialised = JsonConvert.SerializeObject(_personlist);
            File.WriteAllText("AllPerson.json", _serialised);
        }
    }
}
