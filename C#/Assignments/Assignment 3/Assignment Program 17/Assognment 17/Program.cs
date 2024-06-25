using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{

    public class Customer
    {
        private int customerId;
        private string name;
        private int age;
        private long phone;
        private string city;
        public Customer()
        {
            Console.WriteLine("Default constructor called by using this keyword.");
        }
        public Customer(int customerId, string name, int age, long phone, string city) : this()
        {
            Console.WriteLine("Parameterized constructor called after default constructor.");
            this.customerId = customerId;
            this.name = name;
            this.age = age;
            this.phone = phone;
            this.city = city;
        }
        public void DisplayCustomer()
        {
            Console.WriteLine($"Customer ID: {customerId}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Phone: {phone}");
            Console.WriteLine($"City: {city}");
            Console.Read();
        }
        ~Customer()
        {
            Console.WriteLine($"Destructor called for customer {customerId} - {name}");
            Console.Read();
        }
        public static void Main(string[] args)
        {
            Customer customer1 = new Customer(1, "Nithin Jagadeesh", 23, 8904062277, "Bangalore");
            customer1.DisplayCustomer();
            Console.Read();
        }
    }
}