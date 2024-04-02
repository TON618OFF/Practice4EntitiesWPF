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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private BookSystemPractice3Entities genres = new BookSystemPractice3Entities();
        public Page2()
        {
            InitializeComponent();
            dg_BD_books.ItemsSource = genres.Genres.ToList();
            cb_BD_books.ItemsSource = genres.Genres.ToList();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = genres.Genres.ToList().Where(genre => genre.Genre.Contains(SearchText.Text));
        }

        private void cb_BD_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_BD_books.SelectedItem != null)
            {

                var selected = cb_BD_books.SelectedItem as Genres;
                dg_BD_books.ItemsSource = genres.Genres.ToList().Where(genre => genre.Genre == selected.Genre);

            }
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            dg_BD_books.ItemsSource = genres.Genres.ToList();
        }

    }
}
