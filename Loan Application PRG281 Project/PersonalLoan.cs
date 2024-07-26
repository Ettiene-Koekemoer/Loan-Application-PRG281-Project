﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Application_PRG281_Project
{
    internal class PersonalLoan : Loan
    {
		//Class that inherits from Loan class and calculates the new interest rate amount for a personal loan
		public PersonalLoan(string loanNumber, string custFirstName, string custLastName, double loanAmount, int loanTerm, double PrimeRate) : base(loanNumber, custFirstName, custLastName, loanAmount, loanTerm)
        {
            InterestRate = PrimeRate + (PrimeRate * 0.02);
        }
    }
}
