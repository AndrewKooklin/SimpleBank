using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Model
{
    public interface IAccountCovariant<out T>
    {
        T PutMoney(Account account, int sum);
    }
}
