using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace book_api_task.Domain.Core
{
    public class Book
    {
        private static int BookingCount = 1;
        public int Id = 0;
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string Title, string Author)
        {
            this.Id = BookingCount++;
            this.Title = Title;
            this.Author = Author;
        }


    }
}