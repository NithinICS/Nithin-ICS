using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Account
{
    class Account
    {
        long accountNo;
        string customerName;
        string accountType;
        public static int transactionType;
        public static int amount;
        public static int balance;

        public Account()
        {
            accountNo = 3456789098;
            customerName = "Nithin";
            accountType = "Savings";
            balance = 50000;
            Console.WriteLine($"Account no is {accountNo} Customer name is {customerName} Account type is {accountType}");

        }
        public static void getData()
        {
            Console.WriteLine("enter 1 for deposit 2 for withdraw");
            transactionType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter amount");
            amount = Convert.ToInt32(Console.ReadLine());
        }
        public static void credit()
        {
            if (transactionType == 1)
            {
                balance += amount;
            }
        }
        public static void debit()
        {
            if (transactionType == 2)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
        public static void show()
        {
            Console.WriteLine($"after deposit/ withdraw your balance is {balance} ");
        }


        static void Main(string[] args)
        {
            Account a = new Account();
            getData();
            credit();
            debit();
            show();
            Console.Read();
        }
    }
}