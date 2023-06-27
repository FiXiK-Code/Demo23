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
            CalculateDescount();
        }

        /// <summary>
        /// кнопка закрытий окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Метод для рассчета цены со скидкой
        /// </summary>
        private void CalculateDescount()
        {
            var array = App.DB.podzharow_DEMO.ToList();
            foreach(var elem in array)
            {
                if (elem.descount > 0)
                {
                    var output = "";
                    foreach (var symbol in elem.prise.ToString())
                    {
                        output += symbol + "\u0336";
                    }
                    elem.priceToDescount = Convert.ToDouble(elem.prise) - (Convert.ToDouble(elem.prise) * elem.descount / 100);
                    elem.priseOutput = output + "  " + elem.priceToDescount;
                    App.DB.SaveChanges();
                }
                else
                {
                    elem.priceToDescount = elem.prise;
                    elem.priseOutput = elem.priceToDescount.ToString();
                    App.DB.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Метод для подгонки размера столбцов к ширине таблицы
        /// </summary>
        private void ResizeDataGrid()
        {
            try
            {
                double width = DataGrid_products.ActualWidth > 622 ? DataGrid_products.ActualWidth - 270 : 615 - 270;

                for (int i = 0; i < 7; i++)
                {
                    if (i == 6)
                    {
                        DataGridColumn column = DataGrid_products.Columns[i];
                        column.Width = 200;
                    }
                    else if (i == 0)
                    {
                        DataGridColumn column = DataGrid_products.Columns[i];
                        column.Width = 70;
                    }
                    else
                    {
                        DataGridColumn column = DataGrid_products.Columns[i];
                        column.Width = width / 5;
                    }
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод для редизайна контента в таблице
        /// </summary>
        /// <param name="dataContent"></param>
        private void Reload(List<podzharow_DEMO> dataContent)
        {
            try
            {
                DataGrid_products.Columns.Clear();

                DataGridTemplateColumn imageColumn = new DataGridTemplateColumn
                {
                    Header = "Фото"
                };

                DataTemplate imageTemplate = new DataTemplate();
                FrameworkElementFactory imageFactory = new FrameworkElementFactory(typeof(Image));
                imageFactory.SetBinding(Image.SourceProperty, new Binding("img_path"));
                imageTemplate.VisualTree = imageFactory;
                imageColumn.CellTemplate = imageTemplate;

                DataGrid_products.Columns.Add(imageColumn);

                DataGrid_products.AutoGenerateColumns = false;
                DataGridTextColumn textColumn = new DataGridTextColumn
                {
                    Header = "ИМЯ",
                    Binding = new Binding("name")
                };
                DataGrid_products.Columns.Add(textColumn);
                DataGridTextColumn textColumn1 = new DataGridTextColumn
                {
                    Header = "Категория",
                    Binding = new Binding("category")
                };
                DataGrid_products.Columns.Add(textColumn1);
                DataGridTextColumn textColumn2 = new DataGridTextColumn
                {
                    Header = "Цена",
                    Binding = new Binding("priseOutput")
                };
                DataGrid_products.Columns.Add(textColumn2);
                DataGridTextColumn textColumn3 = new DataGridTextColumn
                {
                    Header = "Cкидка%",
                    Binding = new Binding("descount")
                };
                DataGrid_products.Columns.Add(textColumn3);
                DataGridTextColumn textColumn5 = new DataGridTextColumn
                {
                    Header = "Кол-во",
                    Binding = new Binding("count")
                };
                DataGrid_products.Columns.Add(textColumn5);
                DataGridTextColumn textColumn6 = new DataGridTextColumn
                {
                    Header = "Описание",
                    Binding = new Binding("description")
                };
                DataGrid_products.Columns.Add(textColumn6);

                DataGrid_products.ItemsSource = dataContent;

                ResizeDataGrid();
            }
            catch (Exception) { }
        }


        /// <summary>
        /// Отслеживание обновления данных в таблице. Обновление количества отображаемых данных и покраска срок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_products_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                Label_all_item_count.Content = App.DB.podzharow_DEMO.ToList().Count();
                Label_view_item_count.Content = Buffer.prodContent.Count();
                
                var dataobj = e.Row.DataContext as podzharow_DEMO;
                if (dataobj != null && dataobj.descount >= 15)
                {
                    e.Row.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#7fff00");
                }
            }
            catch (Exception) { MessageBox.Show("Error!"); }
        }

        /// <summary>
        /// Сортировка таблицы по цене
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_prise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!Buffer.sort)
                {
                    MessageBoxResult result = MessageBox.Show("Вы хотите применить сортировку?", "", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        switch (ComboBox_prise.SelectedIndex)
                        {
                            case 0:
                                Buffer.prodContent = Buffer.prodContent;
                                Reload(Buffer.prodContent);
                                break;
                            case 1:
                                Buffer.prodContent = Buffer.prodContent.OrderBy(p => p.priceToDescount).ToList();
                                Reload(Buffer.prodContent);
                                break;
                            case 2:
                                Buffer.prodContent = Buffer.prodContent.OrderByDescending(p => p.priceToDescount).ToList();
                                Reload(Buffer.prodContent);
                                break;
                        }
                    }
                }
            }catch (Exception) { MessageBox.Show("Error!"); }
        }

        /// <summary>
        /// Фильтрация по скидкам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_discount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы хотите применить фильтр?", "", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    switch (ComboBox_discount.SelectedIndex)
                    {
                        case 0:
                            Buffer.prodContent = App.DB.podzharow_DEMO.ToList();
                            Buffer.sort = true;
                            ComboBox_prise.SelectedIndex = 0;
                            Buffer.sort = false;
                            Reload(Buffer.prodContent);
                            break;
                        case 1:
                            Buffer.prodContent = App.DB.podzharow_DEMO.Where(p => p.descount >= 0 && p.descount <= 9.99).ToList();
                            Buffer.sort = true;
                            ComboBox_prise.SelectedIndex = 0;
                            Buffer.sort = false;
                            Reload(Buffer.prodContent);
                            break;
                        case 2:
                            Buffer.prodContent = App.DB.podzharow_DEMO.Where(p => p.descount >= 10 && p.descount <= 14.99).ToList();
                            Buffer.sort = true;
                            ComboBox_prise.SelectedIndex = 0;
                            Buffer.sort = false;
                            Reload(Buffer.prodContent);
                            break;
                        case 3:
                            Buffer.prodContent = App.DB.podzharow_DEMO.Where(p => p.descount >= 15).ToList();
                            Buffer.sort = true;
                            ComboBox_prise.SelectedIndex = 0;
                            Buffer.sort = false;
                            Reload(Buffer.prodContent);
                            break;
                    }
                }
            }catch (Exception) { MessageBox.Show("Error!"); }
        }

        /// <summary>
        /// Метод для заполнения таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Buffer.prodContent = App.DB.podzharow_DEMO.ToList();
                Reload(Buffer.prodContent);
            }
            catch (Exception) { MessageBox.Show("Error!"); }
        }

        /// <summary>
        /// Отлавливание измнений размера таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_products_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeDataGrid();
        }
    }
}
