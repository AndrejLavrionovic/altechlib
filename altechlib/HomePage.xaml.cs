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
            tblApplicationName.Text = "Home";
            tblHomeContent.Text = "A library is a collection of sources of information and similar resources," +
                "made accessible to a defined community for reference or borrowing.[1] It provides physical or digital access to material, and may be a physical building or room," +
                "or a virtual space, or both.[2] A library's collection can include books, periodicals, newspapers, manuscripts, films, maps, prints, documents, microform, CDs," +
                "cassettes, videotapes, DVDs, Blu-ray Discs, e-books, audiobooks, databases, and other formats. Libraries range in size from a few shelves of books to several million items." +
                "In Latin and Greek, the idea of a bookcase is represented by Bibliotheca and Bibliothēkē (Greek: βιβλιοθήκη): derivatives of these mean library in many modern languages, e.g. French bibliothèque." +

                "The first libraries consisted of archives of the earliest form of writing—the clay tablets in cuneiform script discovered in Sumer, some dating back to 2600 BC." +
                "Private or personal libraries made up of written books appeared in classical Greece in the 5th century BC.In the 6th century, at the very close of the Classical " +
                "period, the great libraries of the Mediterranean world remained those of Constantinople and Alexandria." +

                "A library is organized for use and maintained by a public body, an institution, a corporation, or a private " +
                "individual.Public and institutional collections and services may be intended for use by people who choose not " +
                "to—or cannot afford to—purchase an extensive collection themselves, who need material no individual can " +
                "reasonably be expected to have, or who require professional assistance with their research.In addition to " +
                "providing materials, libraries also provide the services of librarians who are experts at finding and organizing " +
                "information and at interpreting information needs. Libraries often provide quiet areas for studying, and they also often " +
                "offer common areas to facilitate group study and collaboration.Libraries often provide public facilities for access " +
                "to their electronic resources and the Internet.Modern libraries are increasingly being redefined as places to get unrestricted " +
                "access to information in many formats and from many sources. They are extending services beyond the physical walls of a " +
                "building, by providing material accessible by electronic means, and by providing the assistance of librarians in navigating and " +
                "analyzing very large amounts of information with a variety of digital tools.";
            tblHomeTitle.Text = "About libraries";
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
        
    }
}
