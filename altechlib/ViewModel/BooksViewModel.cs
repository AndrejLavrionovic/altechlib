using altechlib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace altechlib.ViewModel
{
    class BooksViewModel : NotificationBase<Book>
    {
        public BooksViewModel(Book book = null) : base(book) { }

        public String isbn
        {
            get { return This.isbn; }
            set { SetProperty(This.isbn, value, () => This.isbn = value); }
        }

        public String name
        {
            get { return This.name; }
            set { SetProperty(This.name, value, () => This.name = value); }
        }

        public String author
        {
            get { return This.author; }
            set { SetProperty(This.author, value, () => This.author = value); }
        }

        public String content
        {
            get { return This.content; }
            set { SetProperty(This.content, value, () => This.content = value); }
        }
    }
}
