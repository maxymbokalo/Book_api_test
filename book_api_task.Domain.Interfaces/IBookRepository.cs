using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using book_api_task.Domain.Core;

namespace book_api_task.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBookList();
        Book GetBook(int id);
        void Create(Book item);
        void Update(int id,Book item);
        void Delete(int id);
    }
}