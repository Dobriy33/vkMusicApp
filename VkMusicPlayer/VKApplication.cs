﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkMusicPlayer
{
    public static class VKApplication
    {
        private static int appId = 5743605;
        private static int scope = 8 ;
        public  static string connectString = String.Format("https://oauth.vk.com/authorize?client_id={0}&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope={1}+offline&response_type=token&v=5.60", appId, scope);
    }
}
