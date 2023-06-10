using SimpleBank.Help;
using SimpleBank.ViewModel;
using System;
using System.Windows;

namespace SimpleBank.Model
{
    public class Account : ViewModelBase
    {
        public Account()
        {
        }

        public int? Total { get; set; }
    }
}
