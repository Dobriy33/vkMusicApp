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
        int currentItemIndex = 0;//индекс текущей позиции
        private void ChangeMediaSource(int itemIndex) // Смена источника для mediaElement
        {
            Audio currentItem = Audio.audioList[currentItemIndex]; // экземпляр по индексу текущей позиции
            Uri currentItemUri = new Uri(currentItem.url);
            player.Source = currentItemUri;
            
        }
        public AudioList()
        {
            try
            {
                InitializeComponent();
                sldrVolume.Value = 5;
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
            player.Volume = sldrVolume.Value/10;                 // значение громкости для плеера: от 0.0 до 1.0
        }

        private void AudioListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            player.Stop(); // остановит если проигрывается
            currentItemIndex = AudioListBox.SelectedIndex;
            ChangeMediaSource(currentItemIndex);
        }

        private void AudioListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            player.Stop(); // остановить если проигрывается
            currentItemIndex = AudioListBox.SelectedIndex;
            ChangeMediaSource(currentItemIndex);
            txtCurrentItemName.Content = string.Format("{0} - {1}", Audio.audioList[currentItemIndex].artist, Audio.audioList[currentItemIndex].title);
            player.Play();
        }

        private void player_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (currentItemIndex <= Audio.audioList.Count)
            {
                currentItemIndex++;
            }
            else
            {
                currentItemIndex = 0;
            }
            AudioListBox.SelectedIndex = currentItemIndex;
            txtCurrentItemName.Content = string.Format("{0} - {1}", Audio.audioList[currentItemIndex].artist, Audio.audioList[currentItemIndex].title);
            player.Play();

        }
    }
}

