using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public class Saledetails
    {
        private int salesNo;
        private int productNo;
        private double price;
        private DateTime dateOfSale;
        private int qty;
        private double totalAmount;
        public Saledetails(int salesNo, int productNo, double price, int qty, DateTime dateOfSale)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.price = price;
            this.qty = qty;
            this.dateOfSale = dateOfSale;
        }
        public void Sales()
        {
            totalAmount = qty * price;
            Console.WriteLine("Total amount is " + totalAmount);
        }
        public void ShowData()
        {
            Console.WriteLine($"Sales No: {salesNo}");
            Console.WriteLine($"Product No: {productNo}");
            Console.WriteLine($"Price per unit: {price}");
            Console.WriteLine($"Quantity sold: {qty}");
            Console.WriteLine($"Date of Sale: {dateOfSale.ToShortDateString()}");
        }

        public static void Main(string[] args)
        {
            Saledetails sale1 = new Saledetails(1, 552, 50.5, 5, DateTime.Now);
            sale1.ShowData();
            sale1.Sales();
            Console.Read();
        }
    }
}