using altechlib.Data;
using altechlib.ViewModels;
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
            //organization = new OrganizationViewModel(0);

            // Title of Application
            tblApplicationName.Text = "Search & Manage Book";
        }

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
                this.Frame.Navigate(typeof(AddNewBook));
            }
            else if (lbiBorrow.IsSelected)
            {
                this.Frame.Navigate(typeof(SearchBook));
            }
            else if (lbiLend.IsSelected)
            {
                this.Frame.Navigate(typeof(HomePage));
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

        public OrganizationViewModel organization { get; set; }
    }
}
