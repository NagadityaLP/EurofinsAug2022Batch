using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProblemStatementExercise
{
    internal class Account
    {
        string accountNumber;
        string name;
        double balance;
        int pinNumber;
        bool isActive;
        DateTime openingDate ;
        DateTime closingDate;
        bool openingDateSetFlag = false;
        bool closingDateSetFlag = false;

        public Account(string acc_no, string name, double balance, int pin_number)
        {
            this.accountNumber = acc_no;
            this.name = name;
            this.balance = balance;
            this.pinNumber = pin_number;
            this.isActive = true;
        }
        public void Withdraw(double amount , int pin)
        {
            if (balance >= amount && openingDateSetFlag && !closingDateSetFlag && pinNumber == pin)
            {
                balance -= amount;
                Console.WriteLine($"Amount of Rs.{amount} has been successfully withdrwan from the account number {accountNumber} and remaining balance in your account  is Rs {balance}");
            }
            else
                throw new Exception("Insufficient balance");
        }
        public void Deposit(double amount)
        {
            if (isActive && openingDateSetFlag && !closingDateSetFlag)
            {
                balance += amount;
                Console.WriteLine($"Amount of Rs.{amount} has been successfully deposited to the account number {accountNumber} and updated balance in your account  is Rs {balance}");
            }
            else
                throw new Exception("Account has not been opened or closed already");
        }
        public void CloseAccount()
        {
            if (!isActive || balance > 0)
                throw new Exception("Account cannot be closed as either account is inactive or balance is greater than zero");
            if (!closingDateSetFlag) {
                closingDate = DateTime.Now;
                closingDateSetFlag = true;
            }
            else
                throw new Exception("Account closed already");
        }
        public DateTime OpeningDate
        {
            get { return openingDate; }
            set {
                if (!openingDateSetFlag)
                {
                    openingDate = value;
                    openingDateSetFlag = true;
                }
                else
                    throw new Exception("Account opened already and cannot be opened again");
            }
        }
        public void TransferAmount(Account acc, double amount)
        {
            if(isActive && acc.isActive)
            {
                acc.balance += amount;
                this.balance -= amount;
                Console.WriteLine("Amount successfully transferred");
            }
            else
            {
                throw new Exception("Accounts are not active");
            }
        }
    }
}
