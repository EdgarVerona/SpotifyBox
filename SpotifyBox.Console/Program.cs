using Jamcast.Plugins.Spotify.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyBox.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] appKey = File.ReadAllBytes(@"C:\Projects\SpotifyBox\common\keys\spotify_appkey.key");

            Spotify spotify = new Spotify();

            spotify.Login(appKey, "", "");

            var lists = spotify.GetAllSessionPlaylists();

            var list = spotify.GetPlaylist(lists[3], true);

            //"http://www.karaokechamp.com/kcsearch/ajaxsample.php?type=ajax&ar=artist&ti=title&ln=&nr=&pc=1&currentpage=1&lines=10";
            
        }
    }
}
