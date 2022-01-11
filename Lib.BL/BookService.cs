using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.DL;

namespace Lib.BL
{
    public class BookService
    {
        public static BookRepository bookRepository;

        public BookService()
        {
            bookRepository = new BookRepository();
        }

        public string AddNewBook(string name, string author, string category, string language, string publicationDate, string isbn)
        {
            var message = bookRepository.AddNewBook(name, author, category, language, publicationDate, isbn);
            bookRepository.SaveBooksToJsonFile();
            return message;
        }

        public string ShowAvailableBooks(bool arg)
        {
            var message = bookRepository.ShowAvailableBooks(arg);
            return message;
        }

        public string TakeBook(int bookId)
        {
            var message = bookRepository.TakeBook(bookId);
            return message;
        }

        public string DeleteBook(int bookId)
        {
            var message =  bookRepository.DeleteBook(bookId);
            return message;
        }

        public string ReturnBook(int bookId)
        {
            var message = bookRepository.ReturnBook(bookId);
            return message;
        }

        public string FilterBooks(string value)
        {
            return bookRepository.FilterBooks(value);

        }

    }
}
