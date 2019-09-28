using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using book_api_task.Domain.Core;
using book_api_task.Domain.Interfaces;


namespace book_api_task.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        public List<Book> Books;

        public BookRepository()
        {
            this.Books = new List<Book>();
            this.Books.Add(new Book( "Delia Owens", "Where the Crawdads Sing"));
            this.Books.Add(new Book( "Demi Moore", "Inside Out: A Memoir"));
            this.Books.Add(new Book( "Raina Telgemeier", "Guts"));
        }

        public IEnumerable<Book> GetBookList()
        {
            return Books.ToList();
        }

        public Book GetBook(int id)
        {
            var book = Books.FirstOrDefault(c => c.Id == id);
            return book;
        }

        public void Create(Book book)
        {
            Books.Add(book);
        }

        public void Update(int id,Book book)
        {
            var updatedBook = Books.FirstOrDefault(c => c.Id == id);
            updatedBook.Title = book.Title;
            updatedBook.Author = book.Author;


        }

        public void Delete(int id)
        {
            var book = Books.FirstOrDefault(c => c.Id == id);
            Books.Remove(book);

        }
    }
}