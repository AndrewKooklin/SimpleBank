using System;
using System.Windows;

namespace SimpleBank.Model
{
    public class Account : ObjectObservable, IAccount
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

        public void PutMoney(decimal sum)
        {
           Total += sum;

           ShowMessage("На счет внесено " + sum);
        }

        public decimal WithdrawMoney(decimal sum)
        {
            decimal result = 0;
            if (Total >= sum)
            {
                Total -= sum;
                ShowMessage("Со счета снято " + sum);
            }
            else
            {
                ShowMessage($"Недостаточно денег на счете {accountId}");
            }
            return result;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
