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
                var xml = new XmlDocument();
                xml.Load(VkApi.audioGetRequest); //загрузить xml документ по запросу
                StringBuilder output = new StringBuilder();
                XmlReader reader = XmlReader.Create(xml.OuterXml);
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                XmlWriter writer = XmlWriter.Create(output, ws);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            writer.WriteStartElement(reader.Name);
                            break;
                        case XmlNodeType.Text:
                            writer.WriteString(reader.Value);
                            break;
                        case XmlNodeType.XmlDeclaration:
                        case XmlNodeType.ProcessingInstruction:
                            writer.WriteProcessingInstruction(reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            writer.WriteComment(reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            writer.WriteFullEndElement();
                            break;
                    }
                }
            

            /*foreach (XmlNode noda in xml.DocumentElement)
            {
                AudioListBox.Items.Add(string.Format("{0} = {1}", noda.Name, noda.InnerText));
            }*/

            txtTest.Text = output.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
