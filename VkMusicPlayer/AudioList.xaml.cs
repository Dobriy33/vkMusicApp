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
                /* List<Audio> audioList = new List<Audio>();
                 var jObj = VkApi.GetAudioInfo();

                 IList<JToken> results = jObj["response"]["items"].Children().ToList();
                 foreach (JToken result in results)
                 {
                     Audio recrd = JsonConvert.DeserializeObject<Audio>(result.ToString());
                     audioList.Add(recrd);

                 }*/
                Audio.getAudioList();
                foreach (Audio record in Audio.audioList)
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
            player.Play();
        }

        private void MediaPause(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void MediaStop(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = sldrVolume.Value/10; // значение громкости для плеера: от 0.0 до 1.0
        }

        private void AudioListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            player.Stop(); // остановить если проигрывается
            Audio currentItem = Audio.audioList[AudioListBox.SelectedIndex]; //индекс текущей позиции
            Uri currentItemUri = new Uri(currentItem.url); // url адрес для текущего элемента списка 
            player.Source = currentItemUri;
        }

        private void AudioListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            player.Stop(); // остановить если проигрывается
            Audio currentItem = Audio.audioList[AudioListBox.SelectedIndex]; //индекс текущей позиции
            Uri currentItemUri = new Uri(currentItem.url); // url адрес для текущего элемента списка 
            player.Source = currentItemUri;
            player.Play();
        }
    }
}

