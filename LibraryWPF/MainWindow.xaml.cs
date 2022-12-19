using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace LibraryWPF
{

    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
        }

        public LibraryManager LibraryManager { get; private set; }

        public void btnAddBook_Click(object sender, RoutedEventArgs e)
        {// wywołuje funkcje służącą do dodawanie książek
            LibraryManager = new LibraryManager();
            if (!string.IsNullOrEmpty(TXT_title.Text) && !string.IsNullOrEmpty(TXT_author.Text) && !string.IsNullOrEmpty(TXT_isbn.Text) && !string.IsNullOrEmpty(TXT_publisher.Text) && !string.IsNullOrEmpty(TXT_status.Text)){ 
                         
                
                var book = new Book
                {
                    Title = TXT_title.Text,
                    Author = TXT_author.Text,
                    ISBN = TXT_isbn.Text,
                    Publisher = TXT_publisher.Text,
                    Status = TXT_status.Text
                };
                LibraryManager.AddBook(book);
            }


        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        { // wywołuje funkcje służącą do wyszukiwania książek
            LibraryManager = new LibraryManager();
            dgBooks.ItemsSource = LibraryManager.SearchBooks(txtSearch.Text);
        }

        private void btnEditBook_Click(object sender, RoutedEventArgs e)
        {// wywołuje funkcje służącą do edytowania książek
            LibraryManager = new LibraryManager();
            if (!string.IsNullOrEmpty(TXT_title.Text) && !string.IsNullOrEmpty(TXT_author.Text) && !string.IsNullOrEmpty(TXT_isbn.Text) && !string.IsNullOrEmpty(TXT_publisher.Text) && !string.IsNullOrEmpty(TXT_status.Text))
            {
                var book = new Book
                {
                    Title = TXT_title.Text,
                    Author = TXT_author.Text,
                    ISBN = TXT_isbn.Text,
                    Publisher = TXT_publisher.Text,
                    Status = TXT_status.Text
                };
                LibraryManager.EditBook(book);
            }


        }

        private void btnDeleteBook_Click(object sender, RoutedEventArgs e)
        {// wywołuje funkcje służącą do usuwania książek
            LibraryManager = new LibraryManager();
            LibraryManager.DeleteBook(TXT_isbn.Text);
            
        }

        private void btnCheckOutBook_Click(object sender, RoutedEventArgs e)
        {// wywołuje funkcje służącą do oznaczania książek jako wyporzyczone
            LibraryManager = new LibraryManager();
            if (!string.IsNullOrEmpty(TXT_title.Text) && !string.IsNullOrEmpty(TXT_author.Text) && !string.IsNullOrEmpty(TXT_isbn.Text) && !string.IsNullOrEmpty(TXT_publisher.Text) && !string.IsNullOrEmpty(TXT_status.Text))
            { 
                var book = new Book
            {
                Title = TXT_title.Text,
                Author = TXT_author.Text,
                ISBN = TXT_isbn.Text,
                Publisher = TXT_publisher.Text,
                Status = TXT_status.Text
            };
            LibraryManager.Checkout(book);
            }

        }

        private void btnCheckInBook_Click(object sender, RoutedEventArgs e)
        {// wywołuje funkcje służącą do oznaczania książęk jako dostępne
            LibraryManager = new LibraryManager();
            if (!string.IsNullOrEmpty(TXT_isbn.Text))
            {

                var book = new Book
                {
                    Title = TXT_title.Text,
                    Author = TXT_author.Text,
                    ISBN = TXT_isbn.Text,
                    Publisher = TXT_publisher.Text,
                    Status = TXT_status.Text
                };
                LibraryManager.Checkin(book);
            }


        }
    }
}
