// CA3 sample solution - bank account
// author: GC

using System;
using System.Collections;
using System.Text;

namespace Bank
{
    // a bank account
    public class BankAccount : IEnumerable
    {
        // fields
        private String sortCode;
        public String SortCode
        {
            get { return sortCode; }
        }
        
        private String accountNo;
        public String AccountNo
        {
            get { return accountNo; }
        }

        private double balance;                 // €
       public double Balance 
        {
            get { return balance; }
        }
    
        private double overdraftLimit;          // €  
        public double OverDraftLimit
        {
            get { return overdraftLimit; }
        }

        private const int MaxTransactions = 100;
        private double[] transactionHistory;   // a record of amounts deposited and withdrawn
        private int nextTransaction;           // the next free slot in the transactionHistory array 
 
        // constructor
        public BankAccount(String sortCode, String accountNo, double overdraftLimit)
        {
            this.sortCode = sortCode;
            this.accountNo = accountNo;
            this.balance = 0;
            this.overdraftLimit = overdraftLimit;

            transactionHistory = new double[MaxTransactions];
            nextTransaction = 0;                // no transaction to date
        }

        // overloaded constructor - chain
        public BankAccount(String sortCode, String accountNo)
            : this(sortCode, accountNo, 0)
        {
        }

       
        // deposit money in the account
        public void Deposit(double amount)                      // assume amount is positive
        {
            balance += amount;

            // record in transaction history
            transactionHistory[nextTransaction++] = amount;
        }

        // withdraw money if there are sufficient funds
        public void Withdraw(double amount)                     // assume amount is positive
        {
            if ((balance + overdraftLimit) < amount)
            {
                throw new ArgumentException("Insufficient funds");
            }

            balance -= amount;
            transactionHistory[nextTransaction++] = amount * -1;
        }

        // print account details to the console
        public void PrintAccountDetails()
        {
            Console.WriteLine("sort code: " + sortCode + " account no: " + accountNo + " overdraft limit: " + overdraftLimit + " balance: " + balance);
        }

        public override string ToString()
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("sort code: " + sortCode + " account no: " + accountNo + " overdraft limit: " + overdraftLimit + " balance: " + balance);
            sb1.Append(" - Transaction History: ");
            for (int i = 0; i < nextTransaction; i++)
            {
                sb1.Append(transactionHistory[i] + " ");
            }
            return sb1.ToString();

        }


     
        public void PrintTransactionHistory()
        {
            Console.WriteLine("Transaction History:");
            for (int i = 0; i < nextTransaction; i++ )
            {
                Console.Write(transactionHistory[i] + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator GetEnumerator()
        {
            for (int i=0; i< nextTransaction; i++)
            {
                yield return transactionHistory[i];
            }
        }
    }

 
}
