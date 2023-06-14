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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public static ObservableCollection<User> users { get; set; }
        public RegistrationPage()
        {
            InitializeComponent();
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutgorisPage());
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (UniqueLogin(tbLog.Text.Trim()))
            {
                if (tbLog.Text.Trim() != "" && tbPass.Password.Trim() !=""&& tbName.Text.Trim() != "")
                {
                    User user = new User();
                    user.Name = tbName.Text.Trim();
                    user.Login = tbLog.Text.Trim();
                    user.Password = tbPass.Password.Trim();
                    Bdconection.connection.User.Add(user);
                    Bdconection.connection.SaveChanges();
                    System.Windows.MessageBox.Show("Аккаунт успешно создан!");
                    NavigationService.Navigate(new AutgorisPage());
                }
               
            }
           


        }
        public static bool UniqueLogin(string login)
        {
            users = new ObservableCollection<User>(Bdconection.connection.User.ToList());
            bool LoginUnic = true;
            foreach (var i in users)
            {
                if (i.Login == login)
                {
                    LoginUnic = false;
                }
            }
            return LoginUnic;
        }
    }
}
