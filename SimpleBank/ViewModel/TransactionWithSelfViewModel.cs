using SimpleBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.ViewModel
{
    public class TransactionWithSelfViewModel : ViewModelBase
    {
        public string NamePage
        {
            get { return "Между своими счетами"; }
        }
    }
}
