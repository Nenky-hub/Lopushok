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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для knopki.xaml
    /// </summary>
    public partial class knopki : Page
    {
        public knopki()
        {
            InitializeComponent();
        }

        private void BtnMat_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Materials());
        }

        private void BtnProd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Product());
        }

       

        private void BtnSataff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Staff());
;        }

        private void BtnSmens_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Working_shift());
        }

        private void BtnAutorization_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPayMatView_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Ordering_ViewAndDelete());
        }
    }
}
