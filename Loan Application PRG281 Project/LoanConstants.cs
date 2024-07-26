using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Application_PRG281_Project
{
    /*
        Interfaces in C# do not support enums or constants as far as we could tell. Instead, we created an abstract class, 
        fulfilling the same purpose of being a class that consists of constant values and allowing Loan class to inherit.
    */
    abstract class LoanConstants
    {
        public enum LoanTerm
        {
            Short_Term = 1,
            Medium_Term = 3,
            Long_Term = 5
        }

        public const string companyName = "Unique Building Services Loan Company";
        public const int maxLoanAmount = 100_000;
    }
}
