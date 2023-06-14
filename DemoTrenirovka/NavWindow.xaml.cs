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
using System.Windows.Shapes;
using DemoTrenirovka.Pages;

namespace DemoTrenirovka
{
    /// <summary>
    /// Логика взаимодействия для NavWindow.xaml
    /// </summary>
    public partial class NavWindow : Window
    {
        public NavWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new AutgorisPage());
        }
    }
}
