﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VkMusicPlayer
{
    [JsonObject]
    class Audio
    {
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
                return duration;
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
                    duration = String.Format("0:{0}", seconds);
                }

                else if (hours == 0)
                {
                    duration = String.Format("{0}:{1}", minutes, seconds);
                }

                duration = String.Format("{0}:{1}:{2}", hours,minutes,seconds); // hh:mm:ss
            }
        }
        // ссылка на запись
        [JsonProperty("url")]
        public string url { get; set; } 

        public Audio(string Artist, string Title, string Duration, string url)
        {

        }
    }
}
