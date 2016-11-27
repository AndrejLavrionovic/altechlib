using altechlib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace altechlib.Model
{
    class Organization
    {
        public static List<Book> lBookList = new List<Book>();
        public List<Book> books { get; set; }
        public string name { get; set; }

        public Organization(string dbname)
        {
            name = dbname;
            LoadData();
            books = lBookList;
        }

        public static async Task LoadData()
        {
            lBookList = await LoadLocalData();
        }

        public static async Task<List<Book>> LoadLocalData()
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\myBooks.txt");
            var result = await FileIO.ReadTextAsync(file);

            var jBookList = JsonArray.Parse(result);
            return CreateBookList(jBookList);
        }

        // Method creats list of books
        private static List<Book> CreateBookList(JsonArray jBookList)
        {
            List<Book> bl = new List<Book>();
            foreach(var item in jBookList)
            {
                var oneBook = item.GetObject();
                Book nBook = new Book();

                foreach(var key in oneBook.Keys)
                {
                    IJsonValue value;
                    if(!oneBook.TryGetValue(key, out value))
                    {
                        continue;
                    }

                    switch (key)
                    {
                        case "isbn":
                            nBook.isbn = value.GetString();
                            break;
                        case "name":
                            nBook.name = value.GetString();
                            break;
                        case "author":
                            nBook.author = value.GetString();
                            break;
                        case "content":
                            nBook.content = value.GetString();
                            break;
                    } // end switch
                } // end foreach(var key in oneBook.Keys)
                bl.Add(nBook);
            } // end foreach(var item in jBookList)
            return bl;
        }
    }
}
