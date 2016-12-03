using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace altechlib.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Content { get; set; }
        public int Favorite { get; set; }
        public string Image { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
