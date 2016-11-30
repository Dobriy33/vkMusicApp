using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkMusicPlayer
{
    [JsonObject]
    class Audio
    {
        private string _artist;
        private string _title;
        private string _duration;
        private string _url;
        // исполнитель
        [JsonProperty("artist")]
        public string artist { get; set; }
        //название
        [JsonProperty("title")]
        public string title { get; set; }
        //длительность
        [JsonProperty("duration")]
        public string duration
        {
            get
            {
                return _duration;
            }
            set
            {
                
                int s = Convert.ToInt32(value);
                var ts = TimeSpan.FromSeconds(s);
                string sec = (ts.Seconds < 10 ? "0" + ts.Seconds.ToString() : ts.Seconds.ToString());
                
                if (ts.Minutes == 0)
                {
                    _duration = String.Format("0:{0}", sec);
                }

                else if (ts.Hours == 0)
                {
                    _duration = String.Format("{0}:{1}", ts.Minutes, sec);
                }

                else { _duration = String.Format("{0}:{1}:{2}", ts.Hours, ts.Minutes, sec); } // hh:mm:ss*/
            }
        }
        // ссылка на запись
        [JsonProperty("url")]
        public string url { get; set; }

        public Audio(string Artist, string Title, string Duration, string Url)
        {
            artist = Artist;
            title = Title;
            duration = Duration;
            url = Url;
        }
        
    }
}
