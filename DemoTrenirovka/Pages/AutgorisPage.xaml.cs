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
using DemoTrenirovka.DataBase;

namespace DemoTrenirovka.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutgorisPage.xaml
    /// </summary>
    public partial class AutgorisPage : Page
    {
        Random rnd = new Random();
        public string capcha = "";
        public AutgorisPage()
        {
            InitializeComponent();
            UpdateCaptha();
        }
        private void UpdateCaptha()
        {
            CaptchPanel.Children.Clear();
            CanvasNoise.Children.Clear();
            GenerateSymbols(5);
            GenerateNoise(20);
        }
        private void GenerateSymbols(int count)
        {
            string alph = "ABCDEFJHIJKLMNOPQRSTUWXYZ0123456789";
            for(int i = 0; i < count; i++)
            {
                string symbol = alph.ElementAt(rnd.Next(0, alph.Length)).ToString();
                TextBlock lbl = new TextBlock();
                lbl.Text = symbol;
                lbl.FontSize = rnd.Next(5, 70);
                lbl.RenderTransform = new RotateTransform(rnd.Next(-45, 90));
                lbl.Margin = new Thickness(10, 10, 10, 10);
                CaptchPanel.Children.Add(lbl);
                capcha += symbol;

            }
        }
        private void GenerateNoise(int volumeNoise)
        {
            for(int i =0; i<volumeNoise; i++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(100, 256), (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                rectangle.Width = rectangle.Height = rnd.Next(3, 60);
                CanvasNoise.Children.Add(rectangle);
                Canvas.SetLeft(rectangle, rnd.Next(0, 350));

                Canvas.SetBottom(rectangle, rnd.Next(0, 220));
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (capcha == tbCapth.Text.Trim())
            {
                MessageBox.Show("Вход выполнен");
            }
            else
            {
                MessageBox.Show("Неверная капча");
                TextBlock tb = new TextBlock();
                tb.Text = capcha;
                CaptchPanel.Children.Add(tb);
            }

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
