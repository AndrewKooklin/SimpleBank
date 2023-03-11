using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Model
{
    public class RepositoryAccount<T> where T : Account
    {
        List<T> AccountList { get; set; }

        public RepositoryAccount()
        {
            AccountList = new List<T>();
        }

        public void Add(T item)
        {
            AccountList.Add(item);
        }

        public void Remove(int id)
        {
            if(id >= 0) 
            { 
                AccountList.RemoveAt(id);
            }

        }
    }
}
