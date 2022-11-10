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
    /// Логика взаимодействия для Working_shift.xaml
    /// </summary>
    public partial class Working_shift : Page
    {
        public Working_shift()
        {
            InitializeComponent();

            DGWorkingShoft.ItemsSource = lapushokEntities.GetContext().Смены.ToList();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Working_shift_edit((sender as Button).DataContext as Смены));
        }

        private void BtnSataff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Staff());
        }
    }
}
