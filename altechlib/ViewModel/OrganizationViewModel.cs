using altechlib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace altechlib.ViewModel
{
    class OrganizationViewModel : NotificationBase
    {
        Organization organization;
        ObservableCollection<BooksViewModel> _Books = new ObservableCollection<BooksViewModel>();
        int _SelectedIndex;

        public OrganizationViewModel(String name)
        {
            organization = new Organization(name);
            _SelectedIndex = -1;

            // Load database
            foreach (var book in organization.books)
            {
                var np = new BooksViewModel(book);
                //np.PropertyChanged += Dog_OnNotifyPropertyChanged;
                _Books.Add(np);
            }
        }

        public ObservableCollection<BooksViewModel> Books
        {
            get { return _Books; }
            set { SetProperty(ref _Books, value); }
        }

        String _Name;
        public String Name
        {
            get { return organization.name; }
        }

        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value)) { RaisePropertyChanged(nameof(SelectedBook)); }
            }
        }

        public BooksViewModel SelectedBook
        {
            get { return (_SelectedIndex >= 0) ? _Books[_SelectedIndex] : null; }
        }

        /*
        public void Add() {
            var breed = new BreedsViewModel();
            breed.PropertyChanged += Dogs_OnNotifyPropertyChanged;
            Dogs.Add(breed);
            organization.Add(breed);
            SelectedIndex = Dog.IndexOf(breed);
        }

        public void Delete() {
            if (SelectedIndex != -1) {
                var person = People[SelectedIndex];
                People.RemoveAt(SelectedIndex);
                organization.Delete(person);
            }
        }

        void Dog_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e) {
            organization.Update((BreedsViewModel)sender);
        }
        
        */
    }
}
