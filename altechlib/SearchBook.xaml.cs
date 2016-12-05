using altechlib.Data;
using altechlib.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace altechlib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchBook : Page
    {

        // page variables
        String booktitle = null;

        public SearchBook()
        {
            this.InitializeComponent();
            organization = new OrganizationViewModel(0);

            // Title of Application
            tblApplicationName.Text = "Search & Manage Book";
        }

        public OrganizationViewModel organization { get; set; }

        // Side Navigation Menu Section
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private void lbIcons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lbiHome.IsSelected)
            {
                this.Frame.Navigate(typeof(HomePage));
            }
            else if (lbiTransactions.IsSelected)
            {
                this.Frame.Navigate(typeof(SearchBook));
            }
            else if (lbiBorrow.IsSelected)
            {
                this.Frame.Navigate(typeof(AddNewBook));
            }
        }

        private void btnHamburger_Click(object sender, RoutedEventArgs e)
        {
            splSideMenu.IsPaneOpen = !splSideMenu.IsPaneOpen;
        }
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        // End Side Navigation Menu Section


        // Search button click
        private void btnSearchBook_Click(object sender, RoutedEventArgs e)
        {
            // 1) get booktitle
            this.booktitle = tbxBookName.Text;
            
            if (!String.IsNullOrEmpty(this.booktitle)) // if not empty
            {
                // 2) get organization
                organization = new OrganizationViewModel(this.booktitle);
                lstFoundBooks.ItemsSource = organization.Books;
                lstFoundBooks.SelectedIndex = organization.SelectedIndex;
                if(organization.SelectedBook == null)
                    bookDetails.Visibility = Visibility.Collapsed;
                else
                    bookDetails.Visibility = Visibility.Visible;
                
            }
            else
                organization = null;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new LibraryContext())
            {
                // Book obj
                Book book = db.Books.Where(bk => bk.BookId == Convert.ToInt32(tblBookId.Text)).Single();
                // Delete from db
                db.Books.Attach(book);
                db.Books.Remove(book);
                db.SaveChanges();

                this.Frame.Navigate(typeof(SearchBook));
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            lstBookDetails.Visibility = Visibility.Collapsed;
            btnUpdate.Visibility = Visibility.Collapsed;
            lstBookUpdate.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {


            Book book;
            // Get book
            using (var db = new LibraryContext())
            {
                // Book obj
                book = db.Books.Where(bk => bk.BookId == Convert.ToInt32(tblBookId.Text)).Single();
            }

            // Book obj
            book.Isbn = tbxIsbn.Text;
            book.Title = tbxTitle.Text;
            book.Genre = tbxGenre.Text;
            book.Content = tbxContent.Text;
            book.Favorite = Convert.ToInt32(tbxFavorite.Text);
            book.Author = tbxAuthor.Text;

            // Update db
            using (var dbCtx = new LibraryContext())
            {
                dbCtx.Entry(book).State = EntityState.Modified;
                dbCtx.SaveChanges();
            }

            lstBookUpdate.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;

            lstBookDetails.Visibility = Visibility.Visible;
            btnUpdate.Visibility = Visibility.Visible;
        }
    }
}
