using SimpleBank.Command;
using SimpleBank.Commands;
using SimpleBank.Data;
using SimpleBank.Help;
using SimpleBank.Model;
using SimpleBank.Storage;
using SimpleBank.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleBank.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string NamePage
        {
            get { return "Главная"; }
        }

        private SimpleBankContext _db;
        private MainWindowViewModel _mainWindowViewModel;
        private MainWindow _mainWindow;
        private Person _selectedPerson;

        ErrorMessage errorMessage = new ErrorMessage();

        private PersonStorage _personStorage;
        
        private PersonStorage PersonStorage {
            get { return _personStorage; }
            set
            {
                _personStorage = value;
                OnPropertyChanged(nameof(PersonStorage));
            }
        }

        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        
        //private ViewModelBase _leftCurrentViewModel;
        private UserControl _rightCurrentView;

        //public ViewModelBase LeftCurrentViewModel
        //{
        //    get
        //    { 
        //        return _leftCurrentViewModel;
        //    }
        //    set
        //    {
        //        _leftCurrentViewModel = value;
        //        OnPropertyChanged(nameof(LeftCurrentViewModel));
        //    }
        //}

        public UserControl RightCurrentView
        {
            get { return _rightCurrentView; }
            set 
            { 
                _rightCurrentView = value;
                OnPropertyChanged(nameof(RightCurrentView));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public ICommand GetClientsCommand { get; set; }

        public ICommand CreatePersonCommand { get; set; }

        public ICommand ChangePersonCommand { get; set; }

        public ICommand DeletePersonCommand { get; set; }

        public ICommand ClearPersonCommand { get; set; }

        public int? SelectedIndexPerson { get; set; }

        public Person SelectedPerson 
        {
            get 
            {
                if (_selectedPerson == null)
                {
                    //var view = (PersonView)RightCurrentView;

                    SelectedIndexPerson = null;

                    return null;
                }
                if (RightCurrentView == null)
                {
                    return null;
                }
                
                else if(RightCurrentView is PersonView)
                {
                    SelectedIndexPerson = App.mainWindow.lbPersonsItems.SelectedIndex;

                    var view = (PersonView)RightCurrentView;
                    view.tbSelectedIndexPerson.Text = SelectedIndexPerson.ToString();
                    view.tbPersonId.Text = _selectedPerson.PersonId.ToString();
                    view.tbLastName.Text = _selectedPerson.LastName;
                    view.tbFirstName.Text = _selectedPerson.FirstName;
                    view.tbFathersName.Text = _selectedPerson.FathersName;
                    view.tbPhone.Text = _selectedPerson.Phone;
                    view.tbPassportNumber.Text = _selectedPerson.PassportNumber;
                }
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = new Person();
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }

        public MainWindowViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(_db,
                                                        PersonStorage,
                                                        this);

            _mainWindowViewModel = this;

            Persons = new ObservableCollection<Person>();

            Persons = GEtAllPersons(_db);

            CreatePersonCommand = new CreatePersonCommand(_db,
                                                          Persons,
                                                          _mainWindowViewModel,
                                                          _mainWindow);

            ChangePersonCommand = new ChangePersonCommand(_db,
                                                          Persons,
                                                          _mainWindowViewModel,
                                                          _mainWindow);

            DeletePersonCommand = new DeletePersonCommand(_db,
                                                          Persons,
                                                          _mainWindowViewModel,
                                                          _mainWindow);

            ClearPersonCommand = new ClearPersonCommand();
        }

        
        private ObservableCollection<Person> GEtAllPersons(SimpleBankContext db)
        {
            ObservableCollection<Person> _persons = new ObservableCollection<Person>();

            try
            {
                using (db = new SimpleBankContext())
                {
                    foreach (var person in db.Persons.AsEnumerable())
                    {
                        _persons.Add(person);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return _persons;
        }


    }
}
