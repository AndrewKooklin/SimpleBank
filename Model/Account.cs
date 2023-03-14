using SimpleBank.Help;
using System;
using System.Windows;

namespace SimpleBank.Model
{
    public class Account : ObjectObservable, ITransactionWithAccount<decimal>
    {
        public Account(int accountId, decimal total, DateTime dateOpen)
        {
            AccountId = accountId;
            Total = total;
            DateOpen = dateOpen;
        }

        private int accountId;
        private decimal total;
        private DateTime dateOpen;

        public int AccountId {
            get { return accountId; }
            set
            {
                if (value != accountId)
                {
                    accountId = value;
                    OnPropertyChanged("AccountId");
                }
            }
        }

        public decimal Total {
            get { return total; }
            set
            {
                if (value != total)
                {
                    total = value;
                    OnPropertyChanged("Total");
                }
            }
        }

        public DateTime DateOpen {
            get { return dateOpen; }
            set
            {
                if (value != dateOpen)
                {
                    dateOpen = value;
                    OnPropertyChanged("DateOpen");
                }
            }
        }

        public decimal Put(Account account, decimal amount)
        {
            decimal result = account.Total + amount;
            return result;
        }

        public decimal Withdraw(Account account, decimal amount)
        {
            decimal result = 0;

            if (account.Total >= amount)
            {
                result = account.Total - amount;
            }
            else
            {
                ShowMessage($"Недостаточно денег на счете {account.accountId}");
            }
            return result;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
