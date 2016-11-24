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
using System.Text.RegularExpressions;
using System.Web;

namespace VkMusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            AuthWebBrowser.Navigate(VKApplication.connectString);
            
        }

        private void AuthWebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            try
            {
                if (e.Uri.ToString().IndexOf("access_token") != -1)
                {
                    Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    foreach (Match m in myReg.Matches(e.Uri.ToString()))
                    {
                        if (m.Groups["name"].Value == "access_token")
                        {
                            VkApi.userToken = m.Groups["value"].Value;
                        }
                    }
                }
            }
             /*var urlParams = HttpUtility.ParseQueryString(e.Uri.Fragment.Substring(1));
            VkApi.userToken = urlParams.Get("access_token");*/
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            VkApi.SaveToken();
            MessageBox.Show("Авторизация пройдена успешно");
            Task.Delay(5000);
            AudioList audioList = new AudioList();
            audioList.Show();
            this.Close();
        }
    }
}
