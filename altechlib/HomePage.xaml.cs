using altechlib.Models;
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
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            organization = new OrganizationViewModel(1);

            // Title of Application
            tblApplicationName.Text = "Library Home";
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
        
    }
}
