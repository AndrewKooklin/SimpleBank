﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Model
{
    public class SalaryAccount : Account
    {
        public SalaryAccount(int id, decimal total, DateTime dateOpen) : base(id, total, dateOpen)
        {
        }
    }
}
