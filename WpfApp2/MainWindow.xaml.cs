using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Материалы _currentMaterials = new Материалы();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Autorization());
            Manager.MainFrame = MainFrame;
            //ImportProduct();
        }

        public void ImportProduct()
        {
            var fileData = File.ReadAllLines(@"D:\Downloads\Telegram Desktop\Продукция.txt");
            var images = Directory.GetFiles(@"D:\Downloads\Telegram Desktop\products_b_import\products");
            foreach (var line in fileData)
            {
                var data = line.Split('\t');
                var tempmat = new Продукция()
                {
                    Наименование_продукции = data[0].Replace("\"", ""),
                    Артикул = int.Parse(data[1]),

                    Минимальная_стоимость_для_агента = int.Parse(data[2]),
                    Тип_продукции = data[4],
                    Количество_человек_для_производства = int.Parse(data[5]),
                    Номер_цеха_для_производства = int.Parse(data[6])
                };
                try
                {
                    tempmat.Изображение = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(data[3])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                lapushokEntities.GetContext().Продукция.Add(tempmat);
                lapushokEntities.GetContext().SaveChanges();
            }
        }

        private void BtnBck_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_CR(object sender, EventArgs e)
        {
            if( MainFrame.CanGoBack)
            {
              BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility=Visibility.Hidden;
            }
        }
    }
}
