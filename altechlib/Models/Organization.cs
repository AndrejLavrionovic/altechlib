using altechlib.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace altechlib.Models
{
    public class Organization
    {
        public static List<Book> gBookList = new List<Book>();
        public List<Book> books { get; set; }
        public String dbname { get; set; }

        public Organization(String databaseName)
        {
            this.dbname = databaseName;
            LoadData();
            books = gBookList;
        }

        public async static void LoadData()
        {
            await LoadLocalData();
        }

        public static async Task<List<Book>> LoadLocalData()
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\myBooks.txt");
            var result = await FileIO.ReadTextAsync(file);

            var jBookList = JsonArray.Parse(result);
            return CreateBookList(jBookList);
        }

        private static List<Book> CreateBookList(JsonArray jBookList)
        {
            foreach(var item in jBookList)
            {
                var oneBook = item.GetObject();
                Book nBook = new Book();

                foreach(var key in oneBook.Keys)
                {
                    IJsonValue value;
                    if(!oneBook.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "isbn":
                            nBook.isbn = value.GetString();
                            break;
                        case "title":
                            nBook.title = value.GetString();
                            break;
                        case "author":
                            nBook.author = value.GetString();
                            break;
                        case "content":
                            nBook.content = value.GetString();
                            break;
                        case "favorite":
                            nBook.favorite = Convert.ToInt16(value.GetNumber());
                            break;
                        case "img":
                            nBook.img = value.GetString();
                            break;
                    }
                }
                if(nBook.favorite == 5) { gBookList.Add(nBook); }
            }
            return gBookList;
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
