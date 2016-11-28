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
                int seconds, minutes, hours;
                hours = s / 3600;
                minutes = (s - hours * 3600) / 60;
                seconds = s - hours * 3600 - minutes * 60;

                if (minutes == 0)
                {
                    _duration = String.Format("0:{0}", seconds);
                }

                else if (hours == 0)
                {
                    _duration = String.Format("{0}:{1}", minutes, seconds);
                }

                else { _duration = String.Format("{0}:{1}:{2}", hours, minutes, seconds); } // hh:mm:ss*/
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
