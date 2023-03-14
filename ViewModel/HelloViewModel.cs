using SimpleBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.ViewModel
{
    public class HelloViewModel : ObjectObservable, IPageViewModel
    {
        public string NamePage
        {
            get
            {
                return "Начальная страница приложения \"Банк\"";
            }
        }
    }
}
