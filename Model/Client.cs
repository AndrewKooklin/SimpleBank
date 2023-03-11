using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Model
{
    public class Client : Person
    {
        RepositoryAccount<Account> AccountRepository { get; set; }

        public Client() : base()
        {
            AccountRepository = new RepositoryAccount<Account>();
        } 
    }
}
