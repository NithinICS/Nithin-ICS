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

            bookShelf[0] = new Books("Book 1", "Author 1");
            bookShelf[1] = new Books("Book 2", "Author 2");
            bookShelf[2] = new Books("Book 3", "Author 3");
            bookShelf[3] = new Books("Book 4", "Author 4");
            bookShelf[4] = new Books("Book 5", "Author 5");

            bookShelf.DisplayAllBooks();
            Console.ReadLine();

        }
    }
}