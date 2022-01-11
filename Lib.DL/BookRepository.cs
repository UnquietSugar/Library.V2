using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DL
{
    public class BookRepository
    {
        private const string Path = "books.json";

        public List<Book> BookList;

        public BookRepository()
        {
            BookList = new List<Book>();
            var books = GetBookList();

            if (books != null) BookList = books;

        }

        public string AddNewBook(string name, string author, string category, string language, string publicationDate, string isbn)
        {
            Book book;

            if (BookList.Count < 1)
            {
                book = new Book(name,  1,  author,  category,  language,  publicationDate,  isbn);
            }
            else
            {
                var lastBook = BookList.LastOrDefault();
                book = new Book(name, lastBook.Id + 1, author, category, language, publicationDate, isbn);
            }

            BookList.Add(book);

            return $"New book added.\n{book.ToString()}";
        }

        public string ShowAvailableBooks(bool arg)
        {
            string allBooks = "";

            List<Book> availableBooks = BookList.Where(book => book.IsTaken == arg).ToList();

            availableBooks.ForEach(book => allBooks += $"{book.ToString()}\n");

            return allBooks;
        }

        public string TakeBook(int bookId)
        {
            string message;
            var book = BookList.SingleOrDefault(book => book.Id == bookId);
            if(book!= null)
            {
                book.IsTaken = true;
                book.TakenDate = DateTime.UtcNow.Date;
                message = "Book taken.";
            }
            else
            {
                message = "Book not found.";
            }
            SaveBooksToJsonFile();
            return message;
        }


        public string ReturnBook(int bookId)
        {
            string message;

            Book bookToReturn = BookList.SingleOrDefault(book => book.Id == bookId);

            if(bookToReturn != null)
            {
                bookToReturn.IsTaken = false;
                DateTime now = DateTime.UtcNow.Date;
                TimeSpan difference = (TimeSpan)(now - bookToReturn.TakenDate);
 
                
                message = "Book returned to library.";
                if (difference.Days > 60) message += " User is late. :(";
                bookToReturn.TakenDate = null;
                SaveBooksToJsonFile();
            }
            else
            {
                message = "No such book";
            }

            return message;
        }

        public string DeleteBook(int bookId)
        {
            Book bookToDelete = BookList.SingleOrDefault(book => book.Id == bookId);

            BookList.Remove(bookToDelete);

            SaveBooksToJsonFile();

            return "Book deleted.";
        }

        public string FilterBooks( string value)
        {
            string filteredBooks = "";

            List<Book> allBooks = BookList.Where(book => book.Author == value || book.Name == value || book.ISBN == value || book.Language == value || book.PublicationDate == value).ToList();

            allBooks.ForEach(book => filteredBooks += $"{book.ToString()}\n");

            SaveBooksToJsonFile();

            return filteredBooks;
        }

        public List<Book> GetBookList()
        {
            return JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(Path));
        }

        public void SaveBooksToJsonFile()
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(BookList));
        }
    }
}
