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
    /// Логика взаимодействия для Ordering_ViewAndDelete.xaml
    /// </summary>
    public partial class Ordering_ViewAndDelete : Page
    {
        public Ordering_ViewAndDelete()
        {
            InitializeComponent();
            DGOrdVaD.ItemsSource = lapushokEntities.GetContext().Заказ_материалов.ToList();
        }

        private void OrdDelBtn_click(object sender, RoutedEventArgs e)
        {
            var ordForRemoving = DGOrdVaD.SelectedItems.Cast<Заказ_материалов>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ordForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    lapushokEntities.GetContext().Заказ_материалов.RemoveRange(ordForRemoving);
                    lapushokEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGOrdVaD.ItemsSource = lapushokEntities.GetContext().Заказ_материалов.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnPayMat_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Ordering_Materials());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                lapushokEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p=>p.Reload());
                DGOrdVaD.ItemsSource = lapushokEntities.GetContext().Заказ_материалов.ToList();
            }
        }
    }
}
