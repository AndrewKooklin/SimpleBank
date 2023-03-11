using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Model
{
    public class RepositoryClient<T> where T : Client
    {
        public List<T> ClientList { get; set; }

        public RepositoryClient()
        {
            ClientList = new List<T>();
        }
    }
}
