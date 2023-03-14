using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SimpleBank.Help;

namespace SimpleBank.Model
{
    public class Client : Person
    {
        public RepositoryAccount<Account> AccountRepository { get; set; }

        public Client() : base()
        {
            AccountRepository = new RepositoryAccount<Account>();
        }

        private SalaryAccount salaryAccount;
        private DepositAccount depositAccount;

        public SalaryAccount SalaryAccount
        {
            get { return salaryAccount; }
            set
            {
                if (value != salaryAccount)
                {
                    salaryAccount = value;
                    OnPropertyChanged("SalaryAccount");
                }
            }
        }

        public DepositAccount DepositAccount 
        {
            get { return depositAccount; }
            set
            {
                if (value != depositAccount)
                {
                    depositAccount = value;
                    OnPropertyChanged("DepositAccount");
                }
            }
        }

        
    }
}
