using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleBank.Model
{
    public class Account
    {
        public Account(int id, decimal total, DateTime dateOpen)
        {
            Id = id;
            Total = total;
            DateOpen = dateOpen;
        }

        public int Id { get; private set; }

        public decimal Total { get; set; }

        public DateTime DateOpen { get; private set; }

        public virtual void PutMoney(decimal sum)
        {
           Total += sum;

           ShowMessage("На счет внесено " + sum);
        }

        public virtual decimal WithdrawMoney(decimal sum)
        {
            decimal result = 0;
            if (Total >= sum)
            {
                Total -= sum;
                ShowMessage("Со счета снято " + sum);
            }
            else
            {
                ShowMessage($"Недостаточно денег на счете {Id}");
            }
            return result;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
