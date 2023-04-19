using SimpleBank.Model;
using SimpleBank.Storage;
using SimpleBank.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Command
{
    public class PersonCommand : CommandBase
    {
        private readonly PersonViewModel _personViewModel;
        private readonly PersonStorage _personStorage;

        public PersonCommand(PersonViewModel personViewModel, PersonStorage personStorage)
        {
            _personViewModel = personViewModel;
            _personStorage = personStorage;
        }

        public override void Execute(object parameter)
        {
            Person person = new Person()
            {
                LastName = _personViewModel.LastName,
                FirstName = _personViewModel.FirstName,
                FathersName = _personViewModel.FathersName,
                Phone = _personViewModel.Phone,
                PassportNumber = _personViewModel.PassportNumber
            };

            _personStorage.CreatePerson(person);
        }
    }
}
