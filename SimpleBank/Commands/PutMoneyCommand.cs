﻿using SimpleBank.Data;
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
    public class PutMoneyCommand : ICommand
    {
        ObservableCollection<Person> _persons;
        private SimpleBankContext _db;
        private SalaryAccount _salaryAccount;
        private DepositAccount _depositAccount;
        Person person = new Person();
        int newTotal;

        public PutMoneyCommand(ObservableCollection<Person> persons)
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

                bool checkId = Int32.TryParse(textBlockAccountId.Text, out int accountId);
                if (checkId)
                {
                    person = _persons.Single(p => p.PersonId == accountId);
                }
                

                var textBoxInputNumber = (TextBox)childrenStackPanel[8];

                bool parseTextBoxInputNumber = Int32.TryParse(textBoxInputNumber.Text, out int inputNumber);
                if (!parseTextBoxInputNumber)
                {
                    errorMessage.MessageShow("Введите число не более 2000000000");
                    return;
                }

                switch (choose.Content.ToString())
                {
                    case "Зарплатный":
                        try
                        {
                            if(person.TotalSalaryAccount == null)
                            {
                                errorMessage.MessageShow("Откройте счет");
                                return;
                            }
                            string connecionString = @"Data Source=C:\repos\SimpleBank\SimpleBank\Data\SimpleBank.db;New=False;Compress=True;";
                            SQLiteConnection connection = new SQLiteConnection(connecionString);
                            connection.Open();
                            string stringQuery = "";
                            
                            //bool checkId = Int32.TryParse(textBlockAccountId.Text, out int salaryAccountId);
                            if (checkId)
                            {
                                stringQuery = "SELECT TotalSalaryAccount FROM Persons WHERE PersonId=" + accountId + "";
                            }
                            else
                            {
                                errorMessage.MessageShow("Некорректный Id");
                                connection.Close();
                                return;
                            }
                            var SqliteCmd = new SQLiteCommand();
                            SqliteCmd.Connection = connection;
                            SqliteCmd.CommandText = stringQuery;
                            var result = SqliteCmd.ExecuteScalar();
                            //

                            bool convertTotalSalary = Int32.TryParse(result.ToString(), out int totalSalary);
                            if (convertTotalSalary && parseTextBoxInputNumber)
                            {
                                newTotal = totalSalary + inputNumber;
                                if(newTotal > 2100000000 || newTotal < 0)
                                {
                                    errorMessage.MessageShow("Максимальная сумма на счете 2100000000");
                                    connection.Close();
                                    return;
                                }
                                stringQuery = "UPDATE Persons SET TotalSalaryAccount="+newTotal+" WHERE PersonId=" + accountId + "";
                                SqliteCmd.CommandText = stringQuery;
                                SqliteCmd.ExecuteNonQuery();
                                connection.Close();
                            }

                            //person = _persons.Single(p => p.PersonId == accountId);
                            if (person.TotalSalaryAccount != null && newTotal < 2100000000 && newTotal > 0)
                            {
                                person.TotalSalaryAccount = newTotal;
                            }
                            else
                            {
                                errorMessage.MessageShow("Максимальная сумма на счете 2100000000");
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
                        break;
                    case "Депозитный":
                        try
                        {
                            if (person.TotalDepositAccount == null)
                            {
                                errorMessage.MessageShow("Откройте счет");
                                return;
                            }
                            string connecionString = @"Data Source=C:\repos\SimpleBank\SimpleBank\Data\SimpleBank.db;New=False;Compress=True;";
                            SQLiteConnection connection = new SQLiteConnection(connecionString);
                            connection.Open();
                            string stringQuery = "";
                            //bool checkId = Int32.TryParse(textBlockAccountId.Text, out int depositAccountId);
                            if (checkId)
                            {
                                stringQuery = "SELECT TotalDepositAccount FROM Persons WHERE PersonId=" + accountId + "";
                            }
                            else
                            {
                                errorMessage.MessageShow("Некорректный Id");
                                connection.Close();
                                return;
                            }
                            var SqliteCmd = new SQLiteCommand();
                            SqliteCmd.Connection = connection;
                            SqliteCmd.CommandText = stringQuery;
                            var result = SqliteCmd.ExecuteScalar();
                            //

                            bool convertTotalDeposit = Int32.TryParse(result.ToString(), out int totalDeposit);
                            if (convertTotalDeposit && parseTextBoxInputNumber)
                            {
                                newTotal = totalDeposit + inputNumber;
                                if (newTotal > 2100000000 || newTotal < 0)
                                {
                                    errorMessage.MessageShow("Максимальная сумма на счете 2100000000");
                                    connection.Close();
                                    return;
                                }
                                stringQuery = "UPDATE Persons SET TotalDepositAccount=" + newTotal + " WHERE PersonId=" + accountId + "";
                                SqliteCmd.CommandText = stringQuery;
                                SqliteCmd.ExecuteNonQuery();
                                connection.Close();
                            }

                            //person = _persons.Single(p => p.PersonId == depositAccountId);
                            if (person.TotalDepositAccount != null && newTotal < 2100000000 && newTotal > 0)
                            {
                                person.TotalDepositAccount = newTotal;
                            }
                            else
                            {
                                errorMessage.MessageShow("Максимальная сумма на счете 2100000000");
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
                        break;
                    default:
                        errorMessage.MessageShow("Неопределенный тип счета");
                        break;
                }
            }
        }
    }
}
