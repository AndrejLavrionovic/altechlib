﻿using altechlib.Data;
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
            get { return This.Isbn; }
            set { SetProperty(This.Isbn, value, () => This.Isbn = value); }
        }

        public String Title
        {
            get { return This.Title; }
            set { SetProperty(This.Title, value, () => This.Title = value); }
        }

        public String Genre
        {
            get { return This.Genre; }
            set { SetProperty(This.Genre, value, () => This.Genre = value); }
        }
        
        public String Author
        {
            get { return getAuthor(This.Author); }
            set { SetProperty(This.Author.Name, value, () => This.Author.Name = value); }
        }
        

        public String Content
        {
            get { return This.Content; }
            set { SetProperty(This.Content, value, () => This.Content = value); }
        }

        public int Favorite
        {
            get { return This.Favorite; }
            set { SetProperty(This.Favorite, value, () => This.Favorite = value); }
        }

        public String Image
        {
            get { return This.Image; }
            set { SetProperty(This.Image, value, () => This.Image = value); }
        }

        private String getAuthor(Author author)
        {
            return author.Name;
        }
    }
}
