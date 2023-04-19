using SimpleBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Storage
{
    public class PersonStorage
    {
        public event Action<Person> PersonCreated;

        public void CreatePerson(Person person)
        {
            PersonCreated?.Invoke(person);
        }
    }
}
