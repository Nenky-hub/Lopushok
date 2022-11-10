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
    /// Логика взаимодействия для Ordering_Materials.xaml
    /// </summary>
    public partial class Ordering_Materials : Page
    {
        private Заказ_материалов _currentOrder = new Заказ_материалов();
        public Ordering_Materials()
        {
            InitializeComponent();

            DataContext = _currentOrder;
            ComboMaterials.ItemsSource = lapushokEntities.GetContext().Материалы.ToList();
            ComboProd.ItemsSource = lapushokEntities.GetContext().Продукция.ToList();
        }
       
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if(_currentOrder.Материалы == null)
            {
                errors.AppendLine("Название материала не указано");
            }
            //if (_currentOrder.Продукция == null)
            //{
            //    errors.AppendLine("Название продукции не указано");
            //}
            if (_currentOrder.Необходимое_количество_материала == null)
            {
                errors.AppendLine("Необходимое количество материала не указано");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentOrder.ID_Заказ_материалов == 0)
            {
                lapushokEntities.GetContext().Заказ_материалов.Add(_currentOrder);
            }

            try
            {
                lapushokEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
