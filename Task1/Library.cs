using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException("Не удалось добавить книгу.");

            books.Add(book);
        }

        public IEnumerable<Book> GetBooks()
        {
            if (books.Count < 1)
                throw new Exception("Нечего возвращать");

            return books;
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.Where(b => b.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public List<Book> SearchByYear(int year)
        {
            return books.Where(b => b.Year == year).ToList();
        }
    }
}
