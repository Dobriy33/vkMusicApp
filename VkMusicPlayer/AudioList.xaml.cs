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

namespace VkMusicPlayer
{
    /// <summary>
    /// Interaction logic for AudioList.xaml
    /// </summary>
    public partial class AudioList : Window
    {
        public AudioList()
        {
            InitializeComponent();
            var xml = new XmlDocument();
            xml.Load(VkApi.audioGetRequest);
            foreach (XmlNode noda in xml.DocumentElement)
            {
                AudioListBox.Items.Add(string.Format("{0} = {1}", noda.Name, noda.InnerText));
            }

        }
    }
}
