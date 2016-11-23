using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkMusicPlayer
{
    public static class VkApi
    {
        public static string userToken {private get; set; }
        public static string requestString = String.Format("{0}", userToken);
    }
}
