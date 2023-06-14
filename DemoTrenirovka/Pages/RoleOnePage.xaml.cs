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
 using System.Collections.ObjectModel;
using DemoTrenirovka.DataBase;

namespace DemoTrenirovka.Pages
{
    /// <summary>
    /// Interaction logic for RoleOnePage.xaml
    /// </summary>
    public partial class RoleOnePage : Page
    {
        public static ObservableCollection<Product> prod{ get; set; }
        public RoleOnePage()
        {
            InitializeComponent();
            prod = new ObservableCollection<Product>(Bdconection.connection.Product.ToList());
            this.DataContext = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            prod = new ObservableCollection<Product>(Bdconection.connection.Product.ToList());
            if (tbSearch.Text != "")
            {
                prod = new ObservableCollection<Product>(Bdconection.connection.Product.Where(a => a.Title.Contains(tbSearch.Text)).ToList());
            }

            if (prod.Count == 0)
            {
                TbIsEmpty.Visibility = Visibility.Visible;
            }
            else
            {
                TbIsEmpty.Visibility = Visibility.Hidden;
            }
            Lvprod.ItemsSource = prod;
        }

        private void Lvprod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
