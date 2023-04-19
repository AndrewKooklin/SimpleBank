using SimpleBank.Help;
using SimpleBank.ViewModel;
using System;
using System.Windows;

namespace SimpleBank.Model
{
    public class Account : ViewModelBase, ITransactionWithAccount<int>
    {
        public Account()
        {
        }

        public enum AccountType
        {
            Salary,
            Deposit
        }

        public int Total { get; set; }

        public int Put(Account account, int amount)
        {
            int result = account.Total + amount;
            return result;
        }

        public int Withdraw(Account account, int amount)
        {
            int result = 0;

            if (account.Total >= amount)
            {
                result = account.Total - amount;
            }
            else
            {
                ShowMessage($"Недостаточно денег на счете");
            }
            return result;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
