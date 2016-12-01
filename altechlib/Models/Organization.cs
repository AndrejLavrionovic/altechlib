using altechlib.Data;
using System;
using System.Collections.Generic;

namespace altechlib.Models
{
    class Organization
    {
        public List<Book> books { get; set; }
        public String dbname { get; set; }

        public Organization(String databaseName)
        {
            this.dbname = databaseName;
            this.books = FakeService.GetBooks();
        }

        // Working with Fake database here
        // adding, deleting, updating
        public void AddBook(Book book)
        {
            if (!books.Contains(book))
            {
                books.Add(book);
                FakeService.Write(book);
            }
        }

        public void DeleteBook(Book book)
        {
            if (books.Contains(book))
            {
                books.Remove(book);
                FakeService.Delete(book);
            }
        }

        public void Update(Book book)
        {
            if (books.Contains(book))
            {
                FakeService.Write(book);
            }
        }
    }
}
