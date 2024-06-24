using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_Ques_1
{
    class Assignment_4_Ques_3
    {
        public class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException(string message) : base(message) { }
        }

        public class BankAccount
        {
            private decimal balance;

            public BankAccount(decimal balance)
            {
                this.balance = balance;
            }

            public void Deposit(decimal amount)
            {
                balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (balance < amount)
                {
                    throw new InsufficientBalanceException("Insufficient balance in the account.");
                }
                balance -= amount;
            }

            public decimal GetBalance()
            {
                return balance;
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                BankAccount account = new BankAccount(1000);

                try
                {
                    account.Withdraw(500);
                    Console.WriteLine("Balance: " + account.GetBalance());
                    account.Withdraw(600);
                    Console.WriteLine("Balance: " + account.GetBalance());
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                }
            }
        }

    }
}