using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /*class Program
    {
        static void Main(string[] args)
        {
            BankAccount b = new BankAccount("903555", "12344544", 1000);
            b.PrintAccountDetails();
        }
    }
    */

    // test class
    class BankAccountTest
    {
        public static void Main()
        {
            BankAccount b = new BankAccount("903555", "12344544", 1000);
            b.PrintAccountDetails();
            Console.WriteLine("-------------------");
            Console.WriteLine(b.ToString());

            b.Deposit(100);

            try
            {
                b.Withdraw(200);
                Console.WriteLine("Withdrawal was successful");
                b.PrintAccountDetails();
            }
            catch(Exception e)
            {
                Console.WriteLine("Withdrawal failed");
                Console.WriteLine(e.Message);
            }

            b.Deposit(500);
            Console.WriteLine(b.ToString());

      
        }
    }
}

