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
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace VkMusicPlayer
{
    /// <summary>
    /// Interaction logic for AudioList.xaml
    /// </summary>
    public partial class AudioList : Window
    {
        public AudioList()
        {
            try
            {
                InitializeComponent();
                WebClient web = new WebClient();
                string response = web.DownloadString(VkApi.audioGetRequest);
                List<Audio> audioList = new List<Audio>();
                int count = Convert.ToInt32(JsonConvert.DeserializeObject(response));
                for (int i = 0; i < count; i++)
                {
                    var recrd = JsonConvert.DeserializeObject<Audio>(response);
                    audioList.Add(recrd);

                }
                foreach (Audio record in audioList)
                {
                    AudioListBox.Items.Add(string.Format("{0} - {1} {2}/n {3}", record.artist, record.title, record.duration, record.url));

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

