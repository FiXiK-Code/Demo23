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

namespace Pojarov_DEMO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Склад : Window
    {
        public Склад()
        {
            InitializeComponent();
        }

        private void Button_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DataGrid_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (podzharow_DEMO)DataGrid_products.SelectedItem;
            Карточка_товара descriptionWindow = new Карточка_товара(item.id);
            descriptionWindow.Show();
            this.Close();
        }

        private void DataGrid_products_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var dataObj = e.Row.DataContext as Product;
            if(dataObj != null && dataObj.descount >= 15)
            {
                e.Row.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#7fff00");
            }
        }

        private void ComboBox_prise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox_prise.SelectedIndex)
            {
                case 0:
                    DataGrid_products.ItemsSource = App.DB.podzharow_DEMO.ToList();
                    break;
                case 1:
                    DataGrid_products.ItemsSource = App.DB.podzharow_DEMO.OrderBy(p => p.prise).ToList();
                    break;
                case 2:
                    DataGrid_products.ItemsSource = App.DB.podzharow_DEMO.OrderByDescending(p => p.prise).ToList();
                    break;
            }
        }

        private void ComboBox_discount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox_discount.SelectedIndex)
            {
                case 0:
                    DataGrid_products.ItemsSource = App.DB.podzharow_DEMO.ToList();
                    break;
                case 1:
                    DataGrid_products.ItemsSource = App.DB.podzharow_DEMO.Where(p => p.descount>=0 && p.descount <=0.99).ToList();
                    break;
                case 2:
                    DataGrid_products.ItemsSource = App.DB.podzharow_DEMO.Where(p => p.descount >= 10 && p.descount <= 14.99).ToList();
                    break;
                case 3:
                    DataGrid_products.ItemsSource = App.DB.podzharow_DEMO.Where(p => p.descount >= 15).ToList();
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid_products.ItemsSource = App.DB.podzharow_DEMO.ToList();
        }
    }
}
