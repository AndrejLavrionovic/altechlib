using altechlib.Data;
using System;

namespace altechlib.ViewModels
{
    public class BookViewModel : NotificationBase<Book>
    {
        // constructor
        public BookViewModel(Book book = null) : base(book) { }

        public String Isbn
        {
            get { return This.isbn; }
            set { SetProperty(This.isbn, value, () => This.isbn = value); }
        }

        public String Name
        {
            get { return This.name; }
            set { SetProperty(This.name, value, () => This.name = value); }
        }

        public String Author
        {
            get { return This.author; }
            set { SetProperty(This.author, value, () => This.author = value); }
        }

        public String Content
        {
            get { return This.content; }
            set { SetProperty(This.content, value, () => This.content = value); }
        }
    }
}
