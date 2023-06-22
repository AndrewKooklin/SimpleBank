using SimpleBank.Data;
using SimpleBank.Help;
using SimpleBank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleBank.Commands
{
    /// <summary>
    /// Команда удаления счета
    /// </summary>
    public class CloseAccountCommand : ICommand
    {
        ObservableCollection<Person> _persons;
        Person person = new Person();

        public CloseAccountCommand(ObservableCollection<Person> persons)
        {
            _persons = persons;
        }

        ErrorMessage errorMessage = new ErrorMessage();

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is StackPanel)
            {
                var stackPanel = (StackPanel)parameter;
                var childrenStackPanel = stackPanel.Children;

                var textBlockAccountId = (TextBlock)childrenStackPanel[1];
                if (String.IsNullOrWhiteSpace(textBlockAccountId.Text))
                {
                    errorMessage.MessageShow("Выберите клиента");
                    return;
                }
                var comboBoxAccountType = (ComboBox)childrenStackPanel[4];
                var choose = (ComboBoxItem)comboBoxAccountType.SelectedItem;
                if (choose == null)
                {
                    errorMessage.MessageShow("Выберите тип счета");
                    return;
                }

                switch (choose.Content.ToString())
                {
                    case "Зарплатный":
                        try
                        {
                            string connecionString = @"Data Source=C:\repos\SimpleBank\SimpleBank\Data\SimpleBank.db;New=False;Compress=True;";
                            SQLiteConnection connection = new SQLiteConnection(connecionString);
                            connection.Open();
                            string stringQuery = "";
                            bool checkId = Int32.TryParse(textBlockAccountId.Text, out int salaryAccountId);
                            if (checkId)
                            {
                                stringQuery = "SELECT TotalSalaryAccount FROM Persons WHERE PersonId="+salaryAccountId+"";
                            }
                            else
                            {
                                errorMessage.MessageShow("Некорректный Id");
                                return;
                            }
                            var SqliteCmd = new SQLiteCommand();
                            SqliteCmd.Connection = connection;
                            SqliteCmd.CommandText = stringQuery;
                            var result = SqliteCmd.ExecuteScalar();
                            connection.Close();

                            bool convertTotalSalary = Int32.TryParse(result.ToString(), out int totalSalary); 
                            if ( convertTotalSalary && totalSalary > 0)
                            {
                                errorMessage.MessageShow("Для закрытия снимите все деньги со счета");
                                return;
                            }

                            person = _persons.Single(p => p.PersonId == salaryAccountId);
                            if(person.TotalSalaryAccount == 0)
                            {
                                person.TotalSalaryAccount = null;
                            }
                            
                            App.mainWindow.lbPersonsItems.ItemsSource = _persons;
                            App.mainWindow.lbPersonsItems.Items.Refresh();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errorMessage.MessageShow("Не удалось подключиться к базе данных");
                        }
                        break;
                    case "Депозитный":
                        try
                        {
                            string connecionString = @"Data Source=C:\repos\SimpleBank\SimpleBank\Data\SimpleBank.db;New=False;Compress=True;";
                            SQLiteConnection connection = new SQLiteConnection(connecionString);
                            connection.Open();
                            string stringQuery = "";
                            bool checkId = Int32.TryParse(textBlockAccountId.Text, out int depositAccountId);
                            if (checkId)
                            {
                                stringQuery = "SELECT TotalDepositAccount FROM Persons WHERE PersonId=" + depositAccountId + "";
                            }
                            else
                            {
                                errorMessage.MessageShow("Некорректный Id");
                                return;
                            }
                            var SqliteCmd = new SQLiteCommand();
                            SqliteCmd = connection.CreateCommand();
                            SqliteCmd.CommandText = stringQuery;
                            var result = SqliteCmd.ExecuteScalar();
                            connection.Close();

                            bool convertTotalDeposit = Int32.TryParse(result.ToString(), out int totalDeposit);
                            if (convertTotalDeposit && totalDeposit > 0)
                            {
                                errorMessage.MessageShow("Для закрытия снимите все деньги со счета");
                                return;
                            }

                            person = _persons.Single(p => p.PersonId == depositAccountId);
                            if (person.TotalDepositAccount == 0)
                            {
                                person.TotalDepositAccount = null;
                            }

                            App.mainWindow.lbPersonsItems.ItemsSource = _persons;
                            App.mainWindow.lbPersonsItems.Items.Refresh();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errorMessage.MessageShow("Не удалось подключиться к базе данных");
                        }
                        break;
                    default:
                        errorMessage.MessageShow("Неопределенный тип счета");
                        break;
                }
            }
        }
    }
}
