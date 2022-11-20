using System;

namespace Properties_Exercise
{
    internal class SavingsAccountTest
    {
        static void Main(string[] args)
        {
            SavingsAccount account = new SavingsAccount(12345, 234.56);
            Console.WriteLine($"Account with {account.AccountNumber} has been created with a balance of {account.Balance} IsOverDrawn ? {account.IsOverDrawn}     ");
            //passing value to the setter
            account.InterestEarned = 30;
            SavingsAccount.InterestRate = 0.7;
            //accessing value through the getter
            Console.WriteLine($"Interest earned is {account.InterestEarned}");
            Console.WriteLine($"Interest Rate is {SavingsAccount.InterestRate}");
        }
    }
    class SavingsAccount
    {
        private int accountNumber;
        private double balance;
        private double interestEarned;
        private static double interestRate;

        public SavingsAccount(int accountNumber, double balance)
        {
            this.accountNumber = accountNumber; 
            this.balance = balance;
        }
        public int AccountNumber
        {
            get { return accountNumber; }
        }
        public double Balance
        {
            get { return balance; }
        }
        public bool IsOverDrawn
        {
            get { return (balance < 0); }
        }
        public double InterestEarned
        {
            get
            {
                return interestEarned;  
            }
            set
            {
                if(value <= 0)
                    Console.WriteLine("Interest cannot be negative");
                else
                    interestEarned = value; 
            }
        }
        public static double InterestRate
        {
            get
            {
                return interestRate;
            }
            set 
            {
                if (value <= 0)
                    Console.WriteLine("Interest Rate cannot be negative");
                else
                    interestRate = value; 
            }
        }
    }
}
