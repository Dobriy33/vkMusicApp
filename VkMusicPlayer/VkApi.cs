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
    public static class VkApi
    {
        public static string userToken {get; set; }
        public static string requestString = String.Format("{0}", userToken);
        public static string audioGetRequest;
        public static void SaveToken()
        {
            Properties.Settings.Default.UserToken = userToken;
            audioGetRequest = String.Format("https://api.vk.com/method/audio.get?access_token={0}&v=5.60", userToken);
        }
        public static JObject GetAudioInfo()
        {
            WebClient web = new WebClient();
            string response = web.DownloadString(VkApi.audioGetRequest);
            return JObject.Parse(response);
        }
    }
}
