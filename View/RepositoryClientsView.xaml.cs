using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SimpleBank.Model;
using SimpleBank.ViewModel;

namespace SimpleBank.View
{
    /// <summary>
    /// Interaction logic for RepositoryClientsView.xaml
    /// </summary>
    public partial class RepositoryClientsView : UserControl
    {
        public RepositoryClientsView()
        {
            InitializeComponent();

            RepositoryClientsViewModel repositoryClients = new RepositoryClientsViewModel();
            var repClients = repositoryClients.GetRepositoryClientsList();

            clientItems.ItemsSource = repClients;
        }
    }
}
