using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Loan_Application_PRG281_Project.LoanConstants;

namespace Loan_Application_PRG281_Project
{
    internal class Program : LoanConstants
    {
        static void Main(string[] args) 
        {
            CreateLoans createLoans = new CreateLoans();
            createLoans.PromptUser();
            Console.ReadKey();

			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"\n\n\t---------- Thank you for using {companyName}! ----------\n");
            Console.WriteLine("Created by:\n\t- Annika Kritzinger (577322)\n\t- Ettiene Koekemoer (577657)\n\t- Kenneth Mcferrier (577503)\n\t- Joshua Moll (578045)\n\t- Zoë Treutens (577989)");
            Console.ReadLine();
        }
    }
}
