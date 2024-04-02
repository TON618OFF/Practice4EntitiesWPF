using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Practice4EntitiesWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookSystemPractice3Entities books = new BookSystemPractice3Entities();
        public MainWindow()
        {
            InitializeComponent();
            dg_BD_books.ItemsSource = books.Books.ToList();
            cb_BD_books.ItemsSource = books.Books.ToList();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = books.Books.ToList().Where(item => item.Title.Contains(SearchText.Text));
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = books.Books.ToList();
        }

        private void cb_BD_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_BD_books.SelectedItem != null)
            {

                var selected = cb_BD_books.SelectedItem as Books;
                dg_BD_books.ItemsSource = books.Books.ToList().Where(book => book.Title == selected.Title);
                
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page1();
            btn_reset.Visibility = Visibility.Collapsed;
            btn_reset.Visibility = Visibility.Collapsed;
            NextPage.Visibility = Visibility.Collapsed;
            dg_BD_books.Visibility = Visibility.Collapsed;
            cb_BD_books.Visibility = Visibility.Collapsed;
            SearchText.Visibility = Visibility.Collapsed;
            readertxt.Visibility = Visibility.Collapsed;
        }
    }
}
