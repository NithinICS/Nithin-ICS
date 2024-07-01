using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{



    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book Name: {BookName}, Author Name: {AuthorName}");
        }

    }
    public class BookShelf
    {
        private Books[] books;

        public BookShelf(int size)
        {
            books = new Books[size];
        }

        public Books this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }

        public void DisplayAllBooks()
        {
            foreach (var book in books)
            {
                book.Display();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BookShelf bookShelf = new BookShelf(5);

            bookShelf[0] = new Books("A Suitable Boy", "Vikram Seth");
            bookShelf[1] = new Books("The God of Small Things", " Arundhati Roy");
            bookShelf[2] = new Books("The White Tiger", "Aravind Adiga");
            bookShelf[3] = new Books("The Palace of Illusions", " Chitra Banerjee Divakaruni");
            bookShelf[4] = new Books("Cool Guy", "Raghav Garg");

            bookShelf.DisplayAllBooks();
            Console.ReadLine();

        }
    }
}