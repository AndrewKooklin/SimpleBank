using SimpleBank.Model;
using System.Windows.Input;

namespace SimpleBank.ViewModel
{
    class RepositoryClientsViewModel : ObjectObservable, IPageViewModel
    {
        private RepositoryClient<Client> currentRepositoryClient;

        private ICommand getRepositoryClientCommand;
        private ICommand saveRepositoryClientCommand;

        public string Message
        {
            get
            {
                return "Список клиентов";
            }
        }

        public ICommand GetRepositoryClientCommand
        {
            get
            {
                if (getRepositoryClientCommand == null)
                {
                    getRepositoryClientCommand = new RelayCommand(
                        param => GetRepositoryClient(),
                        param => currentRepositoryClient.ClientList.Count > 0
                    );
                }
                return getRepositoryClientCommand;
            }
        }

        public ICommand SaveRepositoryClientCommand
        {
            get
            {
                if (saveRepositoryClientCommand == null)
                {
                    saveRepositoryClientCommand = new RelayCommand(
                        param => SaveRepositoryClient(),
                        param => (CurrentRepositoryClient != null)
                    );
                }
                return saveRepositoryClientCommand;
            }
        }

        public RepositoryClient<Client> CurrentRepositoryClient
        {
            get { return currentRepositoryClient; }
            set
            {
                if (value != currentRepositoryClient)
                {
                    currentRepositoryClient = value;
                    OnPropertyChanged("CurrentRepositoryClient");
                }
            }
        }

        private void GetRepositoryClient()
        {
            // Usually you'd get your Product from your datastore,
            // but for now we'll just return a new object
            RepositoryClient<Client> repositoryClient = new RepositoryClient<Client>();
            
        }

        private void SaveRepositoryClient()
        {
            // You would implement your Product save here
        }
    }
}
