using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace altechlib.Data
{
    class Book
    {
        public string isbn { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string content { get; set; }
    }

    class FakeService
    {
        public static String Name = "Fake Data Service.";

        public static List<Book> GetBooks()
        {
            Debug.WriteLine("GET for books.");
            return new List<Book>()
                {
                    new Book() { isbn="100001", name="Book #1", author = "Andrej Lavrinovic", content = "BlaBlaBlablaBafvoerfojewoirngvernejnfiuerho" },
                    new Book() { isbn="100002", name="Book #2", author = "Tatjana Buta", content = "hbvnkjhsbc;ojbjenfbwiejfpoewjngvhjewnjfpowekjigubfjowiehgiuerjhf" },
                    new Book() { isbn="100003", name="Book #3", author = "Aleksej Belousov", content = "ljahnvrgfnbvjlhsncoefdnblrnfwefjuiwrhguiejfivriutg feiojfh ieurhfe jgfreg" }
                };
        }

        public static void Write(Book book)
        {
            Debug.WriteLine("INSERT book with name " + book.name);
        }

        public static void Delete(Book book)
        {
            Debug.WriteLine("DELETE book with name " + book.name);
        }

    }
}
