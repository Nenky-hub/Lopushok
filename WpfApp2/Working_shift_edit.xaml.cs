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
    /// Логика взаимодействия для Working_shift_edit.xaml
    /// </summary>
    public partial class Working_shift_edit : Page
    {
        private Смены _currentWorking_shift = new Смены();
        public Working_shift_edit(Смены selectedWorking_shift)
        {
            InitializeComponent();
            if(selectedWorking_shift != null)
            {
                _currentWorking_shift = selectedWorking_shift;
            }
            DataContext = _currentWorking_shift;
            ComboMaster.ItemsSource = lapushokEntities.GetContext().Мастер_производства.ToList();
           
        }

        private void savebtn_click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if(_currentWorking_shift.Мастер_производства==null)
            {
                errors.AppendLine("Выбрать мастера смены");
            }
            if(_currentWorking_shift.Время_начало_смены == null)
            {
                errors.AppendLine("Время начала не указано");
            }
            if (_currentWorking_shift.Время_конца_смены == null)
            {
                errors.AppendLine("Время конца не указано");
            }
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_currentWorking_shift.ID_Смены==0)
            {
                lapushokEntities.GetContext().Смены.Add(_currentWorking_shift);
            }
            try
            {
                lapushokEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
