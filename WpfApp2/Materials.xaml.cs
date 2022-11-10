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
    /// Логика взаимодействия для Materials.xaml
    /// </summary>
    public partial class Materials : Page
    {
        public Materials()
        {
            InitializeComponent();

            DGMaterials.ItemsSource = lapushokEntities.GetContext().Материалы.ToList();
        }

        private void BtnPayMatView_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Ordering_ViewAndDelete());
        }

        private void BtnProd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Product());
        }
    }
}
