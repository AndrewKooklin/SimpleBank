using SimpleBank.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleBank.Commands
{
    public class SelectedPersonCommand : ICommand
    {
        private MainWindow _mainWindow;
        private MainWindowViewModel _mainWindowViewModel;

        public SelectedPersonCommand(MainWindowViewModel mainWindowViewModel,
                                       MainWindow mainWindow)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _mainWindow = mainWindow;

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            
        }
    }
}
