using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Model
{
    public class DepositAccount : Account
    {
        public DepositAccount(int id, decimal total, DateTime dateOpen) : base(id, total, dateOpen)
        {
        }

        public int Interest { get; private set; }

        public override void PutMoney(decimal sum)
        {
            base.PutMoney(sum);
        }

        public override decimal WithdrawMoney(decimal sum)
        {
            return base.WithdrawMoney(sum);
        }

        public virtual void AccrueInterest()
        {
            decimal increment = Total * Interest / 100;
            Total += increment;
            ShowMessage("На счет начислены проценты ");
        }
    }
}
