using System;
using System.Collections.Generic;
using Lib.BL;

namespace Lib.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            var bookService = new BookService();
            var userBooksService = new UserBooksService();
            string username;
            string userId = "1";
            string answer;
            string message = "";

            var allUsers = userService.GetAllUsers();

            allUsers.ForEach(user => Console.WriteLine(user.ToString()));

            Console.WriteLine("Hi! Who are you?");
            username = Console.ReadLine();

            Console.WriteLine("Have you been here before? [y/n]");
            answer = Console.ReadLine();

            if (answer.ToLower() == "n")
            {
                message = userService.WelcomeNewUser(username);
                Console.WriteLine(message);
            }
            else if (answer.ToLower() == "y")
            {
                Console.WriteLine("What's your ID? [number]");
                userId = Console.ReadLine();
                message = userService.WelcomeExistingUser(username, userId);
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Wrong input.");
                throw new ArgumentException();
            }

            Console.WriteLine("\n\nChoose action:\n\tadd book- [1]\n\ttake book- [2]\n\treturn book-[3]\n\tdelete book- [4]\n\tfilter books- [5]");
            answer = Console.ReadLine();

            if(answer == "1")
            {
                message = AddNewBook(bookService);
            }
            if (answer == "2")
            {
                message = TakeBook(bookService, userBooksService, Int32.Parse(userId));
            }
            if (answer == "3")
            {
                message = ReturnBook(bookService, userBooksService, Int32.Parse(userId));
            }
            if (answer == "4")
            {
                message = DeleteBook(bookService);
            }
            if (answer == "5")
            {
                message = FilterBooks(bookService);
            }

            Console.WriteLine(message);

            Console.ReadKey();
        }

        static string AddNewBook(BookService bookService)
        {
            Console.WriteLine("\nAdd book.\n");
            Console.WriteLine("Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Author:");
            var author = Console.ReadLine();
            Console.WriteLine("Category:");
            var category = Console.ReadLine();
            Console.WriteLine("Language:");
            var language = Console.ReadLine();
            Console.WriteLine("Publication date:");
            var publicationDate = Console.ReadLine();
            Console.WriteLine("ISBN:");
            var isbn = Console.ReadLine();

            return bookService.AddNewBook(name, author, category, language, publicationDate, isbn);
        }

        static string TakeBook(BookService bookService, UserBooksService userBooksService,int userId)
        {
            string bookId;
            string message;


            Console.WriteLine("\nAvailable books:\n");
            Console.WriteLine(bookService.ShowAvailableBooks(false));

            Console.WriteLine("Pick book by ID. [number]");

            bookId = Console.ReadLine();

            message = bookService.TakeBook(Int32.Parse(bookId)) + " " + userBooksService.TakeBook(userId, Int32.Parse(bookId));

            return message;
        }

        static string ReturnBook(BookService bookService, UserBooksService userBooksService, int userId)
        {
            string bookId;
            string message;
            
            Console.WriteLine(userBooksService.RetriveBookIds(userId));
            Console.WriteLine("Pick a book to return. [book ID]");

            bookId = Console.ReadLine();

            message = userBooksService.ReturnBook(userId, Int32.Parse(bookId)) + " " + bookService.ReturnBook(Int32.Parse(bookId));


            return message;

        }

        static string DeleteBook(BookService bookService)
        {
            string bookId;
            string message;

            Console.WriteLine("\nAvailable books:\n");
            Console.WriteLine(bookService.ShowAvailableBooks(false));

            Console.WriteLine("Pick book by ID. [number]");
            bookId = Console.ReadLine();

            message = bookService.DeleteBook(Int32.Parse(bookId));

            return message;
        }

        static string FilterBooks(BookService bookService)
        {
            string message;
            string answer;

            Console.WriteLine("\nChoose filter by name/author/category/language/isbn- [1], filter books that are available- [2]");
            answer = Console.ReadLine();

            if(answer == "1")
            {
                Console.WriteLine("Enter filter argument.");
                answer = Console.ReadLine();
                message = bookService.FilterBooks(answer);
            }
            else if(answer == "2")
            {
                Console.WriteLine("Available books");
                message = bookService.ShowAvailableBooks(true);

            }
            else
            {
                Console.WriteLine("Wrong input");
                throw new ArgumentException();
            }
            return message;
        }
    }
}
