using Microsoft.Data.Sqlite;
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
    public class OpenAccountCommand : ICommand
    {
        ObservableCollection<Person> _persons;
        private SimpleBankContext _db;
        private SalaryAccount _salaryAccount;
        private DepositAccount _depositAccount;
        Person person = new Person();

        public OpenAccountCommand(ObservableCollection<Person> persons)
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
                if(String.IsNullOrWhiteSpace(textBlockAccountId.Text))
                {
                    errorMessage.MessageShow("Выберите клиента");
                    return;
                }
                var comboBoxAccountType = (ComboBox)childrenStackPanel[4];
                var choose = (ComboBoxItem)comboBoxAccountType.SelectedItem;
                if(choose == null)
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
                                    stringQuery = "INSERT INTO SalaryAccounts ('SalaryAccountId' , 'SalaryTotal' , 'DateSalaryOpen') " +
                                                          "VALUES ('" + salaryAccountId + "' , '"+
                                                          0 + "' , '" + DateTime.Now + "')";
                                }
                                else
                                {
                                    errorMessage.MessageShow("Некорректный Id");
                                    return;
                                }
                                var SqliteCmd = new SQLiteCommand();
                                SqliteCmd = connection.CreateCommand();
                                SqliteCmd.CommandText = stringQuery;
                                SqliteCmd.ExecuteNonQuery();
                                connection.Close();
                            

                            //App.mainWindow.lbPersonsItems.ItemsSource = _persons;
                            //App.mainWindow.lbPersonsItems.Items.Refresh();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
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
                                stringQuery = "INSERT INTO DepositAccounts ('DepositAccountId' , 'DepositTotal' , 'DateDepositOpen') " +
                                                      "VALUES ('" + depositAccountId + "' , '" +
                                                      0 + "' , '" + DateTime.Now + "')";
                            }
                            else
                            {
                                errorMessage.MessageShow("Некорректный Id");
                                return;
                            }
                            var SqliteCmd = new SQLiteCommand();
                            SqliteCmd = connection.CreateCommand();
                            SqliteCmd.CommandText = stringQuery;
                            SqliteCmd.ExecuteNonQuery();
                            connection.Close();

                            //App.mainWindow.lbPersonsItems.ItemsSource = _persons;
                            //App.mainWindow.lbPersonsItems.Items.Refresh();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
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
