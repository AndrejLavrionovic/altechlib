using altechlib.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace altechlib.ViewModels
{
    public class OrganizationViewModel : NotificationBase
    {
        Organization organization;

        public OrganizationViewModel(String name)
        {
            organization = new Organization(name);
            _SelectedIndex = -1;

            // Load the database
            foreach (var book in organization.books)
            {
                var np = new BookViewModel(book);
                np.PropertyChanged += Book_OnNotifyPropertyChanged;
                _Books.Add(np);
            }
        }

        ObservableCollection<BookViewModel> _Books = new ObservableCollection<BookViewModel>();
        public ObservableCollection<BookViewModel> Books
        {
            get { return _Books; }
            set { SetProperty(ref _Books, value); }
        }

        String _Name;
        public String Name
        {
            get { return organization.dbname; }
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
    }
}
