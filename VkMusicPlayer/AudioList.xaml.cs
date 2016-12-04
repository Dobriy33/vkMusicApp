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
using Newtonsoft.Json.Linq;
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

                List<Audio> audioList = new List<Audio>();
                var jObj = VkApi.GetAudioInfo();

                IList<JToken> results = jObj["response"]["items"].Children().ToList();
                foreach (JToken result in results)
                {
                    Audio recrd = JsonConvert.DeserializeObject<Audio>(result.ToString());
                    audioList.Add(recrd);

                }
                foreach (Audio record in audioList)
                {
                    AudioListBox.Items.Add(string.Format("{0} - {1} {2}", record.artist, record.title, record.duration));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MediaPlay(object sender, RoutedEventArgs e)
        {
            
        }

        private void MediaPause(object sender, RoutedEventArgs e)
        {

        }

        private void MediaStop(object sender, RoutedEventArgs e)
        {

        }
    }
}

