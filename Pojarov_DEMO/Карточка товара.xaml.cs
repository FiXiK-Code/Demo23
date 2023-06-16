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
using System.Windows.Shapes;

namespace Pojarov_DEMO
{
    /// <summary>
    /// Логика взаимодействия для Карточка_товара.xaml
    /// </summary>
    public partial class Карточка_товара : Window
    {
        private readonly int _itemId;
        public Карточка_товара(int itemId)
        {
            InitializeComponent();
            _itemId = itemId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var prod = App.DB.podzharow_DEMO.FirstOrDefault(p => p.id == _itemId);
            try
            {
                img_product.Source = new BitmapImage(new Uri(prod.img_path, UriKind.Relative));
            }catch(Exception) {
                img_product.Source = new BitmapImage(new Uri("C:\\Users\\Студент.MOD\\Pictures\\1.png", UriKind.Relative));
            }
            Label_name_product.Content = prod.name;
            TextBlock_description_product.Text = prod.description;
            Label_price.Content = prod.prise;
            Label_descount.Content = prod.descount;
        }

        private void Button_close_Click(object sender, RoutedEventArgs e)
        {
            Склад mainWindow = new Склад();
            mainWindow.Show();
            this.Close();
        }
    }
}
