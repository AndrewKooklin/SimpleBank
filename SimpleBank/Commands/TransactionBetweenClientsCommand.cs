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
    public class TransactionBetweenClientsCommand : ICommand
    {
        ObservableCollection<Person> _persons;
        Person personSend = new Person();
        Person personRecieve = new Person();
        int totalFrom;
        int totalTo;
        int newTotalFrom;
        int newTotalTo;
        bool convertTotalFrom;
        bool convertTotalTo;
        string totalAccountFrom = "";
        string totalAccountTo = "";
        string stringQuery = "";
        string connecionString = @"Data Source=C:\repos\SimpleBank\SimpleBank\Data\SimpleBank.db;New=False;Compress=True;";
        SQLiteCommand SqliteCmd = new SQLiteCommand();

        public TransactionBetweenClientsCommand(ObservableCollection<Person> persons)
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

                var textBlockAccountIdFrom = (TextBlock)childrenStackPanel[1];
                if (String.IsNullOrWhiteSpace(textBlockAccountIdFrom.Text))
                {
                    errorMessage.MessageShow("Выберите клиента отправителя");
                    return;
                }
                bool checkIdFrom = Int32.TryParse(textBlockAccountIdFrom.Text, out int accountIdFrom);
                if (checkIdFrom)
                {
                    personSend = _persons.Single(p => p.PersonId == accountIdFrom);
                }
                else
                {
                    errorMessage.MessageShow("Некорректный Id");
                    return;
                }

                var textBlockAccountIdTo = (TextBlock)childrenStackPanel[6];
                if (String.IsNullOrWhiteSpace(textBlockAccountIdTo.Text))
                {
                    errorMessage.MessageShow("Выберите клиента получателя");
                    return;
                }

                bool checkIdTo = Int32.TryParse(textBlockAccountIdTo.Text, out int accountIdTo);
                if (checkIdTo)
                {
                    personRecieve = _persons.Single(p => p.PersonId == accountIdTo);
                }
                else
                {
                    errorMessage.MessageShow("Некорректный Id");
                    return;
                }

                var comboBoxAccountTypeFrom = (ComboBox)childrenStackPanel[4];
                var chooseAccountFrom = (ComboBoxItem)comboBoxAccountTypeFrom.SelectedItem;
                if (chooseAccountFrom == null)
                {
                    errorMessage.MessageShow("Выберите тип счета списания");
                    return;
                }
                if (chooseAccountFrom.Content.Equals("Зарплатный"))
                {
                    totalAccountFrom = "TotalSalaryAccount";
                    if (personSend.TotalSalaryAccount == null)
                    {
                        errorMessage.MessageShow("Откройте зарплатный счет отправителя и внесите сумму");
                        return;
                    }
                }
                else if (chooseAccountFrom.Content.Equals("Депозитный"))
                {
                    totalAccountFrom = "TotalDepositAccount";
                    if (personSend.TotalDepositAccount == null)
                    {
                        errorMessage.MessageShow("Откройте депозитный счет отправителя и внесите сумму");
                        return;
                    }
                }
                var comboBoxAccountTypeTo = (ComboBox)childrenStackPanel[9];
                var chooseAccountTo = (ComboBoxItem)comboBoxAccountTypeTo.SelectedItem;
                if (chooseAccountTo == null)
                {
                    errorMessage.MessageShow("Выберите тип счета зачисления");
                    return;
                }
                if (chooseAccountTo.Content.Equals("Зарплатный"))
                {
                    totalAccountTo = "TotalSalaryAccount";
                    if (personRecieve.TotalSalaryAccount == null)
                    {
                        errorMessage.MessageShow("Откройте зарплатный счет получателя и внесите сумму");
                        return;
                    }
                }
                else if (chooseAccountTo.Content.Equals("Депозитный"))
                {
                    totalAccountTo = "TotalDepositAccount";
                    if (personRecieve.TotalDepositAccount == null)
                    {
                        errorMessage.MessageShow("Откройте депозитный счет получателя и внесите сумму");
                        return;
                    }
                }

                var textBoxInputNumber = (TextBox)childrenStackPanel[11];

                bool parseTextBoxInputNumber = Int32.TryParse(textBoxInputNumber.Text, out int inputNumber);
                if (!parseTextBoxInputNumber || inputNumber > 2000000000)
                {
                    errorMessage.MessageShow("Введите сумму не более 2000000000");
                    return;
                }

                try
                {
                    SQLiteConnection connection = new SQLiteConnection(connecionString);
                    connection.Open();

                    stringQuery = "SELECT " + totalAccountFrom + " FROM Persons WHERE PersonId=" + accountIdFrom + "";

                    SqliteCmd.Connection = connection;
                    SqliteCmd.CommandText = stringQuery;
                    var resultTotalFrom = SqliteCmd.ExecuteScalar();

                    convertTotalFrom = Int32.TryParse(resultTotalFrom.ToString(), out totalFrom);

                    stringQuery = "SELECT " + totalAccountTo + " FROM Persons WHERE PersonId=" + accountIdTo + "";
                    SqliteCmd.CommandText = stringQuery;
                    var resultTotalTo = SqliteCmd.ExecuteScalar();
                    connection.Close();

                    convertTotalTo = Int32.TryParse(resultTotalTo.ToString(), out totalTo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    errorMessage.MessageShow("Не удалось подключиться к базе данных");
                }


                try
                {
                    SQLiteConnection connection = new SQLiteConnection(connecionString);
                    connection.Open();
                    SqliteCmd.Connection = connection;

                    if (convertTotalFrom && convertTotalFrom && parseTextBoxInputNumber)
                    {
                        newTotalFrom = totalFrom - inputNumber;
                        newTotalTo = totalTo + inputNumber;
                        if (newTotalFrom < 0)
                        {
                            errorMessage.MessageShow("Введенная сумма больше остатка по счету списания");
                            connection.Close();
                            return;
                        }
                        else if (newTotalTo > 2100000000)
                        {
                            errorMessage.MessageShow("Максимальная сумма на счете 2100000000");
                            connection.Close();
                            return;
                        }
                        
                        if (chooseAccountTo.Content.Equals("Зарплатный"))
                        {
                            personRecieve.TotalSalaryAccount = newTotalTo;
                        }
                        else if (chooseAccountTo.Content.Equals("Депозитный"))
                        {
                            personRecieve.TotalDepositAccount = newTotalTo;
                        }
                        
                    }

                    if (newTotalFrom >= 0)
                    {
                        stringQuery = "UPDATE Persons SET "+totalAccountFrom+"=" + newTotalFrom + " WHERE PersonId=" + accountIdFrom + "";
                        SqliteCmd.CommandText = stringQuery;
                        SqliteCmd.ExecuteNonQuery();
                        stringQuery = "UPDATE Persons SET " + totalAccountTo + "=" + newTotalTo + " WHERE PersonId=" + accountIdTo + "";
                        SqliteCmd.CommandText = stringQuery;
                        SqliteCmd.ExecuteNonQuery();
                        connection.Close();

                        if (chooseAccountFrom.Content.Equals("Зарплатный"))
                        {
                            personSend.TotalSalaryAccount = newTotalFrom;
                        }
                        else if (chooseAccountFrom.Content.Equals("Депозитный"))
                        {
                            personSend.TotalDepositAccount = newTotalFrom;
                        }
                    }
                    else
                    {
                        errorMessage.MessageShow("Введенная сумма превышает остаток по счету списания");
                        connection.Close();
                        return;
                    }

                    App.mainWindow.lbPersonsItems.ItemsSource = _persons;
                    App.mainWindow.lbPersonsItems.Items.Refresh();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    errorMessage.MessageShow("Не удалось подключиться к базе данных");
                }
            }
        }
    }
}
