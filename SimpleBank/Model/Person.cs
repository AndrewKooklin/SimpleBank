﻿using SimpleBank.Command;
using SimpleBank.Data;
using SimpleBank.Storage;
using SimpleBank.ViewModel;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleBank.Model
{
    [Table("Persons")]
    public class Person : ViewModelBase
    {
        private int personId;

        private string lastName;

        private string firstName;

        private string fathersName;

        private string phone;

        private string passportNumber;

        PersonStorage _personStorage;

        MainWindowViewModel _mainWindowViewModel;

        SimpleBankContext _simpleBankContext;

        public Person()
        {

        }

        public Person(string lastName, string firstName, string fathersName, string phone, string passportNumber)
        {
            //this.personId = personId;
            this.lastName = lastName;
            this.firstName = firstName;
            this.fathersName = fathersName;
            this.phone = phone;
            this.passportNumber = passportNumber;
        }

        public Person(SimpleBankContext simpleBankContext,
                      PersonStorage personStorage,
                      MainWindowViewModel mainWindowViewModel)
        {
            _simpleBankContext = simpleBankContext;
            _personStorage = personStorage;
            _mainWindowViewModel = mainWindowViewModel;
        }

        [Key, Autoincrement]
        [Unique]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PersonId")]
        public int PersonId
        {
            get { return personId; }
            set
            {
                personId = value;
                OnPropertyChanged("PersonId");
            }
        }

        [Column("LastName")]
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        [Column("FirstName")]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        [Column("FathersName")]
        public string FathersName
        {
            get { return fathersName; }
            set
            {
                fathersName = value;
                OnPropertyChanged("FathersName");
            }
        }

        [Column("Phone")]
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        [Column("PassportNumber")]
        public string PassportNumber
        {
            get { return passportNumber; }
            set
            {
                passportNumber = value;
                OnPropertyChanged("PassportNumber");
            }
        }

        
        [Column("TotalSalaryAccount")]
        public int? TotalSalaryAccount { get; set; }

        [Column("TotalDepositAccount")]
        public int? TotalDepositAccount { get; set; }

        //[Column("PersonSalaryAccount")]
        //public SalaryAccount PersonSalaryAccount { get; set; }

        //[ForeignKey("PersonDepositAccount")]


        //[Column("PersonDepositAccount")]
        //public DepositAccount PersonDepositAccount { get; set; }


    }
}
