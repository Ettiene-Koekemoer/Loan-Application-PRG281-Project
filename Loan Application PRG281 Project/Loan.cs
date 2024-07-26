using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Application_PRG281_Project
{
    abstract class Loan : LoanConstants
    {
        string loanNumber, custFirstName, custLastName;
        double loanAmount, interestRate;
        LoanTerm loanTerm;

        public Loan(string loanNumber, string custFirstName, string custLastName, double loanAmount, int loanTerm)
        {
            this.LoanNumber = loanNumber;
            this.CustFirstName = custFirstName;
            this.CustLastName = custLastName;

            //Validation check for only having a maximum of R100 000 loan
            if (loanAmount > maxLoanAmount)
            {
                this.LoanAmount = maxLoanAmount;
            }
            else
            { 
                this.LoanAmount = loanAmount;
            }

            this.InterestRate = 0;

			//Validation check for forcing a loan term to 1 year if a selection is made outside of the available range
			if (Enum.IsDefined(typeof(LoanTerm), loanTerm))
            {
                this.LoanTerm1 = (LoanTerm)loanTerm;
            } else
            {
                this.LoanTerm1 = (LoanTerm)1;
            }
        }

        public string LoanNumber { get => loanNumber; set => loanNumber = value; }
        public string CustFirstName { get => custFirstName; set => custFirstName = value; }
        public string CustLastName { get => custLastName; set => custLastName = value; }
        public double LoanAmount { get => loanAmount; set => loanAmount = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        internal LoanTerm LoanTerm1 { get => loanTerm; set => loanTerm = value; }

		//Displays the clients details
		public override string ToString()
        {
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			return $"Loan Number:\t\t{LoanNumber}\nCustomer First Name:\t{CustFirstName}\n" +
                        $"Customer Last Name:\t{CustLastName}\nCustomer Loan Amount:\tR{LoanAmount}\n" +
                        $"Interest Rate:\t\t{InterestRate}%\nLoan Term:\t\t{LoanTerm1}\nAmount Due:\t\tR{AmountDue()}";
        }

		//Method to calculate the new loan amount based on the new interest rate
		public double AmountDue()
        {
            double amountDue;            
            switch (LoanTerm1)
            {
				// set up for automatic updating if term length changed from constants
				case LoanTerm.Short_Term:
                {
                    amountDue = LoanAmount * Math.Pow((1 + (InterestRate / 100)), ((double)LoanTerm.Short_Term)); 
                    break;
                }
                case LoanTerm.Medium_Term:
                {
                    amountDue = LoanAmount * Math.Pow((1 + (InterestRate / 100)), ((double)LoanTerm.Medium_Term));
                    break;
                }
                case LoanTerm.Long_Term:
                {
                    amountDue = LoanAmount * Math.Pow((1 + (InterestRate / 100)), ((double)LoanTerm.Long_Term));
                    break;
                }
                default:
                {
                    amountDue = LoanAmount * Math.Pow((1 + (InterestRate / 100)), ((double)LoanTerm.Short_Term));
                    break;
                }
            }
            return Math.Round(amountDue,2);
        }
    }
}
