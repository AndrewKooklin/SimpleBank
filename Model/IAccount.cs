using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Model
{
    public interface IAccount
    {
        void PutMoney(decimal sum);

        decimal WithdrawMoney(decimal sum);
    }
}
