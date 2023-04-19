using SimpleBank.Data;
using SimpleBank.Model;
using SimpleBank.Storage;
using SimpleBank.View;
using SimpleBank.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleBank.Commands
{
    public class UpdateViewCommand : ICommand
    {

        private readonly SimpleBankContext _db = App.db;

        private PersonStorage _personStorage;

        private MainWindowViewModel _mainWindowViewModel;

        public UpdateViewCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public UpdateViewCommand( SimpleBankContext simpleBankContext,
                                  PersonStorage personStorage,
                                  MainWindowViewModel mainWindowViewModel)
        {
            _db = simpleBankContext;
            _personStorage = personStorage;
            _mainWindowViewModel = mainWindowViewModel;
        }

        public UpdateViewCommand()
        {
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Console.WriteLine("text");
            switch (parameter.ToString())
            {
                default:
                //case "Главная":
                //    _mainWindowViewModel.LeftCurrentViewModel = new HelloViewModel();
                //    _mainWindowViewModel.RightCurrentViewModel = null;
                //    break;
                //case "Список":
                //    _mainWindowViewModel.LeftCurrentViewModel = null;
                //    _mainWindowViewModel.LeftCurrentViewModel = new RepositoryClientsViewModel(_mainWindowViewModel);
                //    break;
                case "Добавить":
                case "Изменить":
                case  "Удалить":
                    _mainWindowViewModel.RightCurrentView = new PersonView();
                    break;
                case "Открыть":
                case "Закрыть":
                    _mainWindowViewModel.RightCurrentView = new AccountActionView();
                    break;
                case "Между своими счетами":
                    _mainWindowViewModel.RightCurrentView = new TransactionWithSelfView();
                    break;
                case "Между клиентами":
                    _mainWindowViewModel.RightCurrentView = new TransactionBetweenClientsView();
                    break;

            }
            
        }
    }
}
