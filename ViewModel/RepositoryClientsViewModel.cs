using SimpleBank.Model;
using System.Collections.Generic;
using System.Windows.Input;

namespace SimpleBank.ViewModel
{
    public class RepositoryClientsViewModel : ObjectObservable, IPageViewModel
    {
        private RepositoryClient<Client> currentRepositoryClient;

        private ICommand getRepositoryClientCommand;
        private ICommand saveRepositoryClientCommand;

        public string NamePage
        {
            get
            {
                return "Список";
            }
        }

        public ICommand GetRepositoryClientCommand
        {
            get
            {
                if (getRepositoryClientCommand == null)
                {
                    getRepositoryClientCommand = new RelayCommand(
                        param => GetRepositoryClients(),
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

        private void GetRepositoryClients()
        {
            // Usually you'd get your Product from your datastore,
            // but for now we'll just return a new object
            RepositoryClient<Client> repositoryClient = new RepositoryClient<Client>();
            repositoryClient.ClientList = new List<Client>()
                {
            new Client{ PersonId = 1,
                        LastName = "Michailov",
                        FirstName = "Vitor",
                        FathersName = "Stepanovich",
                        Phone = 89256521545,
                        PassportNumber = "1254-15478"},
            new Client{ PersonId = 2,
                        LastName = "Michailov",
                        FirstName = "Vitor",
                        FathersName = "Stepanovich",
                        Phone = 89256521545,
                        PassportNumber = "1254-15478"},
            new Client{ PersonId = 3,
                        LastName = "Michailov",
                        FirstName = "Vitor",
                        FathersName = "Stepanovich",
                        Phone = 89256521545,
                        PassportNumber = "1254-15478"}
            };    
        }

        public List<Client> GetRepositoryClientsList()
        {
            // Usually you'd get your Product from your datastore,
            // but for now we'll just return a new object
            RepositoryClient<Client> repositoryClient = new RepositoryClient<Client>();
            repositoryClient.ClientList = new List<Client>()
                {
            new Client{ PersonId = 1,
                        LastName = "Michailov",
                        FirstName = "Vitor",
                        FathersName = "Stepanovich",
                        Phone = 89256521545,
                        PassportNumber = "1254-15478"},
            new Client{ PersonId = 2,
                        LastName = "Michailov",
                        FirstName = "Vitor",
                        FathersName = "Stepanovich",
                        Phone = 89256521545,
                        PassportNumber = "1254-15478"},
            new Client{ PersonId = 3,
                        LastName = "Michailov",
                        FirstName = "Vitor",
                        FathersName = "Stepanovich",
                        Phone = 89256521545,
                        PassportNumber = "1254-15478"}
            };

            return repositoryClient.ClientList;
        }

        private void SaveRepositoryClient()
        {
            // You would implement your Product save here
        }
    }
}
