using altechlib.Data;
using altechlib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace altechlib.ViewModels
{
    public class OrganizationViewModel : NotificationBase
    {
        Organization org;

        // constructor #1
        public OrganizationViewModel(int lvlf)
        {
            _SelectedIndex = -1;

            List<Book> books = new List<Book>();
            
            books = getBooksByFavorites(lvlf);
            
            // Load the database
            foreach (var book in books)
            {
                var np = new BookViewModel(book);
                //np.PropertyChanged += Book_OnNotifyPropertyChanged;
                _Books.Add(np);
            }
        }

        // Parameterized constructor
        public OrganizationViewModel(String titlename)
        {
            _SelectedIndex = -1;

            List<Book> books = new List<Book>();

            books = OVMgetBooksByNmae(titlename);

            // Load the database
            foreach (var book in books)
            {
                var np = new BookViewModel(book);
                //np.PropertyChanged += Book_OnNotifyPropertyChanged;
                _Books.Add(np);
            }
        }

        // helper for retrieveing books
        //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        // 1) for default constructor
        private List<Book> getBooksByFavorites(int lvlFavorite)
        {
            org = new Organization();
            return org.CreateBookListByFavorites(lvlFavorite);
        }

        // 2) for parameterazed constructor
        private List<Book> OVMgetBooksByNmae(String title)
        {
            org = new Organization();

            if (title != null)
                return org.getBooksByNmae(title);
            else return new List<Book>();
        }
        //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        // end helper for retrieveing books

        ObservableCollection<BookViewModel> _Books = new ObservableCollection<BookViewModel>();
        public ObservableCollection<BookViewModel> Books
        {
            get { return _Books; }
            set { SetProperty(ref _Books, value); }
        }

        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedBook)); }
            }
        }

        public BookViewModel SelectedBook
        {
            get { return (_SelectedIndex >= 0) ? _Books[_SelectedIndex] : null; }
        }


        /*
        public void AddBook()
        {
            var book = new BookViewModel();
            book.PropertyChanged += Book_OnNotifyPropertyChanged;
            Books.Add(book);
            organization.AddBook(book);
            SelectedIndex = Books.IndexOf(book);
        }

        public void DeleteBook()
        {
            if (SelectedIndex != -1)
            {
                var book = Books[SelectedIndex];
                Books.RemoveAt(SelectedIndex);
                organization.DeleteBook(book);
            }
        }

        void Book_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            organization.Update((BookViewModel)sender);
        }
        */
    }
}
