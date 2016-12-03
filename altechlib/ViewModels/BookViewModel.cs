using altechlib.Data;
using System;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

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

        public String Title
        {
            get { return This.title; }
            set { SetProperty(This.title, value, () => This.title = value); }
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

        public int Favorite
        {
            get { return This.favorite; }
            set { SetProperty(This.favorite, value, () => This.favorite = value); }
        }

        public String Image
        {
            get { return This.img; }
            set { SetProperty(This.img, value, () => This.img = value); }
        }

        public BitmapImage MyImage
        {
            get { return getImage(This.img); }
        }

        private BitmapImage getImage(String path)
        {
            BitmapImage src = new BitmapImage();
            //src.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            src.UriSource = new Uri(path, UriKind.Relative);
            return null;
        }
    }
}
