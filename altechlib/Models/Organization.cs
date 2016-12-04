using altechlib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace altechlib.Models
{
    public class Organization
    {
        public List<Book> books { get; set; }
        public String dbname { get; set; }

        public const int GET_BY_TITLE = 1;
        public const int GET_BY_FAVORITE = 2;

        public Organization() {}

        public List<Book> CreateBookList()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.ToList();
            }
        }

        public List<Book> CreateBookListByFavorites(int lvlFavorites)
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Where(bk => bk.Favorite.Equals(lvlFavorites)).ToList();
            }
        }

        // get books that match given name in book title
        public List<Book> getBooksByNmae(String name)
        {
            using(var db = new LibraryContext())
            {
                return db.Books.Where(bk => bk.Title.Contains("name")).ToList();
            }
        }

        /*
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
        */
    }
}
