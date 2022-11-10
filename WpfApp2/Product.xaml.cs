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
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        public Product()
        {
            InitializeComponent();
            var currentprod = lapushokEntities.GetContext().Продукция.ToList();

            LViewTours.ItemsSource = currentprod;
            UpdateMaterials();
            ComboType.ItemsSource = new List<string> { "Все типы", "Три слоя", "Два слоя", "Детская", "Супер мягкая", "Один слой" };
            ComboType.SelectedIndex = 0;

            ComboSort.ItemsSource = new List<string> { "Все типы", "По названию", "Количеству человек", "Минимальная стоимость" };
            ComboSort.SelectedIndex = 0;

        }
        private void UpdateMaterials()
        {
            var currentprod = lapushokEntities.GetContext().Продукция.ToList();

            if (ComboType.SelectedIndex > 0)
            {
                currentprod = currentprod.Where(p => p.Тип_продукции.Contains(ComboType.SelectedItem.ToString())).ToList();
            }

            currentprod = currentprod.Where(p => p.Наименование_продукции.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            if (ComboSort.SelectedIndex > 0)
            {

                if (ComboSort.SelectedItem.ToString() == "По названию")
                {
                    currentprod = currentprod.OrderBy(p => p.Наименование_продукции).ToList();
                }
                else if (ComboSort.SelectedItem.ToString() == "Количеству человек")
                {
                    currentprod = currentprod.OrderBy(p => p.Количество_человек_для_производства).ToList();
                }
                else if (ComboSort.SelectedItem.ToString() == "Минимальная стоимость")
                {
                    currentprod = currentprod.OrderBy(p => p.Минимальная_стоимость_для_агента).ToList();
                }

            }

            LViewTours.ItemsSource = currentprod;
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMaterials();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateMaterials();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMaterials();
        }
    }
}
