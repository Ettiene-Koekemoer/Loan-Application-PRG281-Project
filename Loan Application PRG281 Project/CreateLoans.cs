using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Loan_Application_PRG281_Project.LoanConstants;

namespace Loan_Application_PRG281_Project
{
    internal class CreateLoans : LoanConstants
    {
        enum LoanType
        {
            personal = 1,
            business,
        }

        enum TermChoice
        {
            shortT = 1,
            mediumT,
            longT
        }
        public void PromptUser()
        {
            string loanNumber, custFirstName, custLastName;
            double loanAmount, primeRate;
            int loanTerm;

            // list is used due to variables having varying data types, and arrays requiring matching data types
            List<Loan> LoanList = new List<Loan>();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n\t---------- Welcome to {companyName}! ----------\n");
            Console.Write("Enter the current Prime Interest rate:\t");
            Console.ForegroundColor = ConsoleColor.White;
            primeRate = double.Parse(Console.ReadLine());

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nEnter loan number:\t\t");
                Console.ForegroundColor = ConsoleColor.White;
                loanNumber = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter client's first name:\t");
                Console.ForegroundColor = ConsoleColor.White;
                custFirstName = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter client's last name:\t");
                Console.ForegroundColor = ConsoleColor.White;
                custLastName = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter loan amount:\t\t");
                Console.ForegroundColor = ConsoleColor.White;
                loanAmount = double.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nEnter the loan term through the corresponding number:\n\t1 - Short term (1 year)\n\t2 - Medium term (3 years)\n\t3 - Long term (5 years)");
                Console.Write("\nChosen loan term: \t\t");
                Console.ForegroundColor = ConsoleColor.White;
                int choice = Convert.ToInt32(Console.ReadLine());
                switch ((TermChoice)choice)
                {
                    case TermChoice.shortT:
                    {
						// set up for automatic updating if term length changed from constants
						loanTerm = ((int)LoanTerm.Short_Term); 
                        break;
                    }
                    case TermChoice.mediumT:
                    {
                        loanTerm = ((int)LoanTerm.Medium_Term);
                        break;
                    }
                    case TermChoice.longT:
                    {
                        loanTerm = ((int)LoanTerm.Long_Term);
                        break;
                    }
                    default:
                    {
                        loanTerm = ((int)LoanTerm.Short_Term);
                        break;
                    }
                }

                //Assigning client information to a specified list according to the choice of loan type
                bool Continue = true;

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
				    Console.WriteLine("\nEnter a loan type through a corresponding number:");
                    Console.WriteLine("\t1 - Personal Loan\n\t2 - Business Loan");
				    Console.Write("\nChosen loan term: \t\t");
				    Console.ForegroundColor = ConsoleColor.White;
				    int option = Convert.ToInt32(Console.ReadLine());
                    switch ((LoanType)option)
                    {
                        case LoanType.personal:
                        {
                            Continue = false;
                            PersonalLoan personalLoan = new PersonalLoan(loanNumber, custFirstName, custLastName, loanAmount, loanTerm, primeRate);
                            LoanList.Add(personalLoan);
                            break;
                        }
                        case LoanType.business:
                        {
                            Continue = false;
                            BusinessLoan businessLoan = new BusinessLoan(loanNumber, custFirstName, custLastName, loanAmount, loanTerm, primeRate);
                            LoanList.Add(businessLoan);
                            break;
                        }
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Please enter either 1 or 2...");
                            Console.WriteLine("---------------------------------------");
                            break;
                    }
                } while (Continue);

            }

            //Displays all 5 client details
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t---------- Client List Details ----------");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Loan loan in LoanList)
            {
                Console.WriteLine("\n");
                Console.WriteLine(loan.ToString());                                
            }
        }
    }
}
