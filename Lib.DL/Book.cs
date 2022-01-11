using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DL
{
    public class Book
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string PublicationDate { get; set; }
        public string ISBN { get; set; }
        public bool IsTaken { get; set; }
        public DateTime? TakenDate;

        public Book(string name, int id, string author, string category, string language, string publicationDate, string isbn)
        {
            Name = name;
            Id = id;
            Author = author;
            Category = category;
            Language = language;
            PublicationDate = publicationDate;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return string.Format($"Book information:\n\tName: {Name}\n\tID: {Id}\n\tAuthor: {Author}\n\tCategory:{Category}\n\tLanguage:{Language}\n\tPublication date: {PublicationDate}\n\tISBN: {ISBN}");
        }
    }
}
