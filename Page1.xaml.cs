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

namespace Practice4EntitiesWPF
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private BookSystemPractice3Entities authors = new BookSystemPractice3Entities();
        public Page1()
        {
            InitializeComponent();
            dg_BD_books.ItemsSource = authors.Authors.ToList();
            cb_BD_books.ItemsSource = authors.Authors.ToList();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = authors.Authors.ToList().Where(author => author.AuthorSurname.Contains(SearchText.Text));
        }

        private void cb_BD_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_BD_books.SelectedItem != null)
            {

                var selected = cb_BD_books.SelectedItem as Authors;
                dg_BD_books.ItemsSource = authors.Authors.ToList().Where(author => author.AuthorName == selected.AuthorName);

            }
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = authors.Authors.ToList();
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page2();
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
