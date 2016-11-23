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

namespace VkMusicPlayer
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        public LoadWindow()
        {
            InitializeComponent();
            if (Properties.Settings.Default.UserToken.Length == 0)
            {
                lblHello.Content = "Здравствуйте! Требуется авторизация.";
                btnAuth.IsEnabled = true;
            }
            else
            {
                lblHello.Content = "Загружаем список аудиозаписей";
                btnAuth.IsEnabled = false;
            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
