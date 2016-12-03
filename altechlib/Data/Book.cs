using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace altechlib.Data
{
    public class Book
    {
        public string isbn { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string content { get; set; }
        public int favorite { get; set; }
        public string img { get; set; }
    }
}
