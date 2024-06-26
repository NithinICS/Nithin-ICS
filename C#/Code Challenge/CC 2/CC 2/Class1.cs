using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2CC2
{
    class Assesment_2_Q2
    {
        // Product class
        public class Product
        {
            // Properties of Product 
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
        }

        class Program
        {
            static void Main()
            {
                // list to the products
                List<Product> products = new List<Product>();

                // Accept 10 products 
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"Enter details for Product {i}:");
                    Product product = new Product();

                    // Accept ProductId
                    Console.Write("Product ID: ");
                    product.ProductId = int.Parse(Console.ReadLine());


                    // Accept ProductName
                    Console.Write("Product Name: ");
                    product.ProductName = Console.ReadLine();

                    // Accept Price
                    Console.Write("Price: ");
                    product.Price = decimal.Parse(Console.ReadLine());

                    // Add the product to the list
                    products.Add(product);
                }

                // Sort product base on Price (ascending order)
                products.Sort((p1, p10) => p1.Price.CompareTo(p10.Price));

                // sorted products
                Console.WriteLine("\nSorted Products by Price:");
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price:C}");
                }
            }

        }
    }
}