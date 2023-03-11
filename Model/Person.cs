using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Model
{
    public class Person : ObjectObservable
    {
        private int personId;

        public string lastName;

        public string firstName;

        public string fathersName;

        public long phone;

        public string passportNumber;

        public Person()
        {
        }

        public int PersonId {
            get { return personId; }
            set
            {
                if (value != personId)
                {
                    personId = value;
                    OnPropertyChanged("PersonId");
                }
            }
        }

        public string LastName {
            get { return lastName; }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        
        public string FirstName {
            get { return firstName; }
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        
        public string FathersName {
            get { return fathersName; }
            set
            {
                if (value != fathersName)
                {
                    fathersName = value;
                    OnPropertyChanged("FathersName");
                }
            }
        }
        
        public long Phone {
            get { return phone; }
            set
            {
                if (value != phone)
                {
                    phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        
        public string PassportNumber {
            get { return passportNumber; }
            set
            {
                if (value != passportNumber)
                {
                    passportNumber = value;
                    OnPropertyChanged("PassportNumber");
                }
            }
        }
    }
}
